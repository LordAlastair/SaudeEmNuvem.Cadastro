using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Documento : ValueObject
    {
        public TipoDocumento TipoDocumento { get; }
        public int NumeroDocumento { get; }
        public byte[] Image { get; }
        public string Meta { get; }

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
