using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class TipoSanguineo : Enumeration
    {
        public static TipoSanguineo APositivo = new TipoSanguineo(1, "A+");
        public static TipoSanguineo ANegativo = new TipoSanguineo(2, "A-");
        public static TipoSanguineo ABPositivo = new TipoSanguineo(3, "AB+");
        public static TipoSanguineo ABNegativo = new TipoSanguineo(4, "AB-");
        public static TipoSanguineo BPositivo = new TipoSanguineo(5, "B+");
        public static TipoSanguineo BNegativo = new TipoSanguineo(6, "B-");
        public static TipoSanguineo OPositivo = new TipoSanguineo(7, "O+");
        public static TipoSanguineo ONegativo = new TipoSanguineo(8, "O-");

        private TipoSanguineo() { }

        public TipoSanguineo(int id, string nome)
            : base(id, nome)
        {

        }

        public static IEnumerable<TipoSanguineo> List()
        {
            return new[] { APositivo, ANegativo, ABPositivo, ABNegativo, BPositivo, BNegativo, OPositivo, ONegativo };
        }

        public static TipoSanguineo BuscarPeloNome(string nome)
        {
            var situacao = List()
                .SingleOrDefault(t => String.Equals(t.Name, nome, StringComparison.CurrentCultureIgnoreCase));
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para tipo sanguíneo: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }

        public static TipoSanguineo BuscarPeloCodigo(int id)
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
