using Autofac;
using SaudeEmNuvem.BuildingBlocks.EventBus.Abstractions;
using SaudeEmNuvem.Cadastro.API.Application.Commands;
using SaudeEmNuvem.Cadastro.Infrastructure.Idempotency;
using System.Reflection;

namespace SaudeEmNuvem.Cadastro.API.Infrastructure.AutofacModules
{
    public class ApplicationModule
        : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CriarCadastroCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
