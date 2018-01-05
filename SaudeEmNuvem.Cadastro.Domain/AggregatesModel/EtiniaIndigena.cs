using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class EtiniaIndigena : ValueObject
    {
        public int ChaveNatural { get; set; }
        public string Etnia { get; set; }

        protected EtiniaIndigena() { }
        public EtiniaIndigena(int chaveNatural, string etnia)
        {
            ChaveNatural = chaveNatural;
            Etnia = etnia;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ChaveNatural;
            yield return Etnia;
        }
    }
}
