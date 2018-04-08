using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Cor : Enumeration
    {
        private static readonly Cor NaoInformado = new Cor(0, "Não Informado");
        private static readonly Cor Branca = new Cor(1, "BRANCA");
        private static readonly Cor Preta = new Cor(2, "PRETA");
        private static readonly Cor Parda = new Cor(3, "PARDA");
        private static readonly Cor Amarela = new Cor(4, "AMARELA");
        private static readonly Cor Indigena = new Cor(5, "INDÍGENA");

        protected Cor() { }

        public Cor(int id, string nome)
            : base(id, nome) { }

        public static IEnumerable<Cor> List()
        {
            return new[] { Branca, Preta, Parda, Amarela, Indigena, NaoInformado };
        }

        public static Cor BuscarPeloNome(string nome)
        {
            var situacao = List()
                .SingleOrDefault(n => String.Equals(n.Name, nome, StringComparison.CurrentCultureIgnoreCase));
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para cor: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }

        public static Cor BuscarPeloCodigo(int id)
        {
            var situacao = List()
                .SingleOrDefault(c => c.Id == id);
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para cor: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }
    }
}
