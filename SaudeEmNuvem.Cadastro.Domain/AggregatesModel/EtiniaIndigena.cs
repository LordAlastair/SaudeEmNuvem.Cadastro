using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class EtiniaIndigena : ValueObject
    {
        public int ChaveNatural { get; set; }
        public String Etnia { get; set; }
        private EtiniaIndigena() { }

        public EtiniaIndigena(int chaveNatural, String etnia)
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
