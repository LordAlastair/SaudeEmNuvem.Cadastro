using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class TipoSanguineo : Enumeration
    {
        public static TipoSanguineo NaoInformado = new TipoSanguineo(0, "Não Informado");
        public static TipoSanguineo APositivo = new TipoSanguineo(1, "A+");
        public static TipoSanguineo ANegativo = new TipoSanguineo(2, "A-");
        public static TipoSanguineo AbPositivo = new TipoSanguineo(3, "AB+");
        public static TipoSanguineo AbNegativo = new TipoSanguineo(4, "AB-");
        public static TipoSanguineo BPositivo = new TipoSanguineo(5, "B+");
        public static TipoSanguineo BNegativo = new TipoSanguineo(6, "B-");
        public static TipoSanguineo OPositivo = new TipoSanguineo(7, "O+");
        public static TipoSanguineo ONegativo = new TipoSanguineo(8, "O-");

        protected TipoSanguineo() { }
        public TipoSanguineo(int id, string nome)
            : base(id, nome)
        {
        }

        public static IEnumerable<TipoSanguineo> List()
        {
            return new[] { APositivo, ANegativo, AbPositivo, AbNegativo, BPositivo, BNegativo, OPositivo, ONegativo };
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
