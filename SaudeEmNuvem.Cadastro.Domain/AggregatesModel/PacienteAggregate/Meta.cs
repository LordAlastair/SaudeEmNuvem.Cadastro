using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Meta : ValueObject
    {
        public Meta() { }

        public Meta(string chaveNatural)
        {
            ChaveNatural = chaveNatural;
        }

        public string ChaveNatural { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ChaveNatural;
        }
    }
}
