using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly CadastroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PacienteRepository(CadastroContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public Paciente Adicionar(Paciente paciente) => _context.Pacientes.Add(paciente).Entity;

        public Paciente Atualizar(Paciente paciente) => _context.Pacientes.Update(paciente).Entity;

        public async Task<List<Paciente>> BuscarPorNomeAsync(string nome) =>
            await _context.Pacientes.Include(p => p.Endereco).Where(p => p.Pessoa.Nome == nome).ToListAsync();

        public async Task<Paciente> BuscarPorChaveNaturalAsync(string pacienteChaveNatural) =>
            await _context.Pacientes.Where(p => p.Meta.ChaveNatural == pacienteChaveNatural).SingleOrDefaultAsync();

        public async Task<List<Paciente>> BuscarPorDataNascimentoAsync(DateTime date) =>
            await _context.Pacientes.Where(p => p.Pessoa.DataNascimento == date).ToListAsync();
    }
}
