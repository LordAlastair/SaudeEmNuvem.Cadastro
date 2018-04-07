using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Meta : ValueObject
    {
        public Meta() { }

        public Meta(string chaveNatural)
        {
            ChaveNatural = chaveNatural;
        }

        public string ChaveNatural { get;   }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ChaveNatural;
        }
    }
}
