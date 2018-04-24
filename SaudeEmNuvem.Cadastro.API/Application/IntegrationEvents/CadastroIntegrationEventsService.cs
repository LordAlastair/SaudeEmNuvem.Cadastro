using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SaudeEmNuvem.BuildingBlocks.EventBus.Abstractions;
using SaudeEmNuvem.BuildingBlocks.EventBus.Events;
using SaudeEmNuvem.BuildingBlocks.EventBus.IntegrationEventLogEF.Services;
using SaudeEmNuvem.BuildingBlocks.EventBus.IntegrationEventLogEF.Utilities;
using SaudeEmNuvem.Cadastro.Infrastructure;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.IntegrationEvents
{
    public class CadastroIntegrationEventsService : ICadastroIntegrationEventsService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly CadastroContext _cadastroContext;
        private readonly IIntegrationEventLogService _eventLogService;

        public CadastroIntegrationEventsService(Func<DbConnection,
            IIntegrationEventLogService> integrationEventLogServiceFactory, IEventBus eventBus,
            CadastroContext cadastroContext, IIntegrationEventLogService eventLogService)
        {
            _cadastroContext = cadastroContext ?? throw new ArgumentNullException(nameof(cadastroContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_cadastroContext.Database.GetDbConnection());
        }

        public async Task PublicarPeloEventBusAsync(IntegrationEvent evt)
        {
            await SalvarAlteracoesNoContextoEvento(evt);
            _eventBus.Publish(evt);
            await _eventLogService.MarkEventAsPublishedAsync(evt);
        }

        private async Task SalvarAlteracoesNoContextoEvento(IntegrationEvent evt)
        {
            await ResilientTransaction.New(_cadastroContext)
                .ExecuteAsync(async () =>
                {
                    // Achieving atomicity between original ordering database operation and the IntegrationEventLog thanks to a local transaction
                    await _cadastroContext.SaveChangesAsync();
                    await _eventLogService.SaveEventAsync(evt, _cadastroContext.Database.CurrentTransaction.GetDbTransaction());
                });
        }
    }
}
