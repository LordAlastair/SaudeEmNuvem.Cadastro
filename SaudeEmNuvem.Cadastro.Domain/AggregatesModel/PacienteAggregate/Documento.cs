using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Documento : ValueObject
    {
        public TipoDocumento TipoDocumento { get; }
        public int NumeroDocumento { get; }
        public byte[] ImageDocumento { get; }
        public string MetaDocumento { get; }

        private Documento() { }

        public Documento(TipoDocumento tipoDocumento, int numeroDocumento, byte[] imageDocumento, string metaDocumento)
        {
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            ImageDocumento = imageDocumento;
            MetaDocumento = metaDocumento;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return TipoDocumento;
            yield return NumeroDocumento;
            yield return ImageDocumento;
            yield return MetaDocumento;
        }
    }
}
