using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Documento : ValueObject
    {
        public TipoDocumento TipoDocumento { get; private set; }
        public int NumeroDocumento { get; private set; }
        public byte[] Image { get; private set; }
        public string Meta { get; private set; }

        protected Documento() { }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TipoDocumento;
            yield return NumeroDocumento;
            yield return Image;
            yield return Meta;
        }
    }
}