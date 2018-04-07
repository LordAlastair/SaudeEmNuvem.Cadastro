using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    //OBS: Não é atestado de obito, apenas a confirmação que o funcionario envia para o sus avisando que o paciente faleceu 
    public class Obito : ValueObject
    {
        public string Medico { get; }
        public DateTime Horario { get; }
        public string Descricao { get; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Medico;
            yield return Horario;
            yield return Descricao;
        }
    }
}
