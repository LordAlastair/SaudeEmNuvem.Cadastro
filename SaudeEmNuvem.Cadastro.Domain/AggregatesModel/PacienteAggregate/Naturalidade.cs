using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Naturalidade : ValueObject
    {
        public string MunicipioNascimento { get; private set; }
        public string PaisNascimento { get; private set; }
        public bool? Nomade { get; private set; }

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
