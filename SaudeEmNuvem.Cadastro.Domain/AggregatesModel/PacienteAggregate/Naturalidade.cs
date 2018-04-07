using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Naturalidade : ValueObject
    {
        public string MunicipioNascimento { get; }
        public string PaisNascimento { get; }
        public bool? Nomade { get; }

        protected Naturalidade() { }

        public Naturalidade(string municipioNascimento, string paisNascimento, bool? nomade)
        {
            MunicipioNascimento = municipioNascimento;
            PaisNascimento = paisNascimento;
            Nomade = nomade;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MunicipioNascimento;
            yield return PaisNascimento;
            yield return Nomade;
        }
    }
}
