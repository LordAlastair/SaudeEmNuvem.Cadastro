using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.Infrastructure
{
    public sealed class CadastroContext
        : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "cadastro";
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Nacionalidade> Nacionalidades { get; set; }
        public DbSet<TipoSanguineo> TipoSanguineos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Sexo> Sexos { get; set; }

        private readonly IMediator _mediator;

        private CadastroContext(DbContextOptions<CadastroContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("CadastroContext::ctor ->" + GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NacionalidadeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PacienteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SexoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoDocumentoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoSanguineoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoTelefoneEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            await SaveChangesAsync(cancellationToken);

            return true;
        }

        public class CadastroContextDesignFactory : IDesignTimeDbContextFactory<CadastroContext>
        {
            public static CadastroContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CadastroContext>()
                    .UseSqlServer("Server=.;Initial Catalog=SaudeEmNuvem.Services.Cadastro;Integrated Security=true");

                return new CadastroContext(optionsBuilder.Options, new NoMediator());
            }

            class NoMediator : IMediator
            {
                public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken) where TNotification : INotification
                {
                    return Task.CompletedTask;
                }

                public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
                {
                    return Task.FromResult(default(TResponse));
                }

                public Task Send(IRequest request, CancellationToken cancellationToken)
                {
                    return Task.CompletedTask;
                }
            }

            CadastroContext IDesignTimeDbContextFactory<CadastroContext>.CreateDbContext(string[] args)
            {
                return CreateDbContext(args);
            }
        }
    }
}
