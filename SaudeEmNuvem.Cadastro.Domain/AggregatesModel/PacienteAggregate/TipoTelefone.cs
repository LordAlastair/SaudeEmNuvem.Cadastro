using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class TipoTelefone : Enumeration
    {
        private static readonly TipoTelefone Outro = new TipoTelefone(1, "Outro");
        private static readonly TipoTelefone BIP = new TipoTelefone(2, "BIP");
        private static readonly TipoTelefone Celular = new TipoTelefone(3, "Celular");
        private static readonly TipoTelefone CelularCorporativo = new TipoTelefone(4, "Celular Corporativo");
        private static readonly TipoTelefone Comercial = new TipoTelefone(5, "Comercial");
        private static readonly TipoTelefone Contato = new TipoTelefone(6, "Contato");
        private static readonly TipoTelefone Fax = new TipoTelefone(7, "Fax");
        private static readonly TipoTelefone Público = new TipoTelefone(8, "Público");
        private static readonly TipoTelefone Residencial = new TipoTelefone(9, "Residencial");

        protected TipoTelefone() { }
        public TipoTelefone(int id, string nome)
            : base(id, nome)
        {
        }

        public static IEnumerable<TipoTelefone> List()
        {
            return new[] { Outro, BIP, Celular, CelularCorporativo, Comercial, Contato, Fax, Público, Residencial };
        }

        public static TipoTelefone BuscarPeloNome(string nome)
        {
            var situacao = List()
                .SingleOrDefault(t => String.Equals(t.Name, nome, StringComparison.CurrentCultureIgnoreCase));
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para tipo sanguíneo: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }

        public static TipoTelefone BuscarPeloCodigo(int id)
        {
            var situacao = List()
                .SingleOrDefault(c => c.Id == id);
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis tipo sanguíneo: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }
    }
}
