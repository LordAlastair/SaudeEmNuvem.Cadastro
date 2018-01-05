using System;
using System.Collections.Generic;
using System.Linq;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class TipoTelefone : Enumeration
    {
        public static TipoTelefone BIP = new TipoTelefone(1, "BIP");
        public static TipoTelefone Celular = new TipoTelefone(2, "Celular");
        public static TipoTelefone CelularCorporativo = new TipoTelefone(3, "Celular Corporativo");
        public static TipoTelefone Comercial = new TipoTelefone(4, "Comercial");
        public static TipoTelefone Contato = new TipoTelefone(5, "Contato");
        public static TipoTelefone Fax = new TipoTelefone(6, "Fax");
        public static TipoTelefone Outro = new TipoTelefone(7, "Outro");
        public static TipoTelefone Público = new TipoTelefone(8, "Público");
        public static TipoTelefone Residencial = new TipoTelefone(9, "Residencial");

        protected TipoTelefone() { }
        public TipoTelefone(int id, string nome)
            : base(id, nome)
        {
        }

        public static IEnumerable<TipoTelefone> List()
        {
            return new[] { BIP, Celular, CelularCorporativo, Comercial, Contato, Fax, Outro, Público, Residencial };
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