using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations;

namespace SaudeEmNuvem.Cadastro.Infrastructure
{
    public class CadastroContext
        : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "cadastro";
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Nacionalidade> Nacionalidades { get; set; }
        public DbSet<TipoSanguineo> TipoSanguineos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Sexo> Sexos { get; set; }

        private readonly IMediator _mediator;

        private CadastroContext(DbContextOptions<CadastroContext> options) : base(options) { }

        private CadastroContext(DbContextOptions<CadastroContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("CadastroContext::ctor ->" + this.GetHashCode());
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

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync();

            return true;
        }

        public class CadastroContextDesignFactory : IDesignTimeDbContextFactory<CadastroContext>
        {
            public CadastroContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<CadastroContext>()
                    .UseSqlServer("Server=.;Initial Catalog=SaudeEmNuvem.Services.Cadastro;Integrated Security=true");

                return new CadastroContext(optionsBuilder.Options, new NoMediator());
            }

            class NoMediator : IMediator
            {
                public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
                {
                    return Task.CompletedTask;
                }

                public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
                {
                    return Task.FromResult<TResponse>(default(TResponse));
                }

                public Task Send(IRequest request, CancellationToken cancellationToken = default(CancellationToken))
                {
                    return Task.CompletedTask;
                }
            }
        }
    }
}
