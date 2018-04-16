using Autofac;
using SaudeEmNuvem.Cadastro.BuildingBlocks.EventBus.Abstractions;
using SaudeEmNuvem.Cadastro.API.Application.Commands;
using SaudeEmNuvem.Cadastro.API.Application.Queries;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.Paciente;
using SaudeEmNuvem.Cadastro.Infrastructure.Idempotency;
using SaudeEmNuvem.Cadastro.Infrastructure.Repositories;
using System.Reflection;

namespace SaudeEmNuvem.Cadastro.API.Infrastructure.AutofacModules
{
    public class ApplicationModule
        :Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new PacienteQueries(QueriesConnectionString))
                .As<IPacienteQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CriarPacienteCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
