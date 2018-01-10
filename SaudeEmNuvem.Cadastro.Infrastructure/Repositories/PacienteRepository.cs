using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Infrastructure.Repositories
{
    public class PacienteRepository :  IPacienteRepository
    {
        private readonly CadastroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PacienteRepository(CadastroContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public Paciente Adicionar(Paciente paciente) => throw new NotImplementedException();




        public void Atualizar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task<List<Paciente>> BuscarPorNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<List<Paciente>> BuscarPorChaveNaturalAsync(int pacienteChaveNatural)
        {
            throw new NotImplementedException();
        }

        public Task<List<Paciente>> BuscarPorDataNascimentoAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
