using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Paciente Adicionar(Paciente paciente);
        void Atualizar(Paciente paciente);
        Task<List<Paciente>> BuscarPorNomeAsync(string nome);
        Task<List<Paciente>> BuscarPorChaveNaturalAsync(int pacienteChaveNatural);
        Task<List<Paciente>> BuscarPorDataNascimentoAsync(DateTime date);
    }
}
