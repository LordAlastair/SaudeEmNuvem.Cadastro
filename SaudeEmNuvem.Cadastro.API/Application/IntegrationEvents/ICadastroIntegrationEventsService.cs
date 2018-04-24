using SaudeEmNuvem.BuildingBlocks.EventBus.Events;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.IntegrationEvents
{
    public interface ICadastroIntegrationEventsService
    {
        Task PublicarPeloEventBusAsync(IntegrationEvent evt);
    }
}
