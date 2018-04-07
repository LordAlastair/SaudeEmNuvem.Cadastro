using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Paciente Adicionar(Paciente paciente);
        Paciente Atualizar(Paciente paciente);
        Task<List<Paciente>> BuscarPorNomeAsync(string nome);
        Task<Paciente> BuscarPorChaveNaturalAsync(string pacienteChaveNatural);
        Task<List<Paciente>> BuscarPorDataNascimentoAsync(DateTime date);
    }
}
