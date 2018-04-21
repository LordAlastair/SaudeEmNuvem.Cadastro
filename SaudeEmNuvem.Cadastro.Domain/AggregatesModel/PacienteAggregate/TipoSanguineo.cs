using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class TipoSanguineo : Enumeration
    {
        private static readonly TipoSanguineo NaoInformado = new TipoSanguineo(1, "Não Informado");
        private static readonly TipoSanguineo APositivo = new TipoSanguineo(2, "A+");
        private static readonly TipoSanguineo ANegativo = new TipoSanguineo(3, "A-");
        private static readonly TipoSanguineo AbPositivo = new TipoSanguineo(4, "AB+");
        private static readonly TipoSanguineo AbNegativo = new TipoSanguineo(5, "AB-");
        private static readonly TipoSanguineo BPositivo = new TipoSanguineo(6, "B+");
        private static readonly TipoSanguineo BNegativo = new TipoSanguineo(7, "B-");
        private static readonly TipoSanguineo OPositivo = new TipoSanguineo(8, "O+");
        private static readonly TipoSanguineo ONegativo = new TipoSanguineo(9, "O-");

        protected TipoSanguineo() { }
        public TipoSanguineo(int id, string nome)
            : base(id, nome)
        {
        }

        public static IEnumerable<TipoSanguineo> List()
        {
            return new[] { APositivo, ANegativo, AbPositivo, AbNegativo, BPositivo, BNegativo, OPositivo, ONegativo, NaoInformado };
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
