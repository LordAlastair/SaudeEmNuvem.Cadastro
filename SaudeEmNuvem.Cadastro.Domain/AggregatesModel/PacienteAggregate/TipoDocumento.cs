using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class TipoDocumento : Enumeration
    {
        private static readonly TipoDocumento Outro = new TipoDocumento(1, "Outro");
        private static readonly TipoDocumento CPF = new TipoDocumento(2, "CPF");
        private static readonly TipoDocumento RG = new TipoDocumento(3, "RG");
        private static readonly TipoDocumento DNV = new TipoDocumento(4, "DNV");
        private static readonly TipoDocumento InscricaoSocial = new TipoDocumento(5, "NIS/PIS/PASEP");

        protected TipoDocumento() { }

        protected TipoDocumento(int id, string nome)
            : base(id, nome) { }

        public static IEnumerable<TipoDocumento> List()
        {
            return new[] { Outro, CPF, RG, DNV, InscricaoSocial };
        }

        public static TipoDocumento BuscarPeloNome(string nome)
        {
            var situacao = List()
                .SingleOrDefault(n => String.Equals(n.Name, nome, StringComparison.CurrentCultureIgnoreCase));
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para tipo de documento: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }

        public static TipoDocumento BuscarPeloCodigo(int id)
        {
            var situacao = List()
                .SingleOrDefault(c => c.Id == id);
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para tipo de documento: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }
    }
}
