using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

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

        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
