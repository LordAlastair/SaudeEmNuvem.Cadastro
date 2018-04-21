using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Sexo : Enumeration
    {
        private static readonly Sexo NaoInformado = new Sexo(1, "Não Informado");
        private static readonly Sexo Masculino = new Sexo(2, "Masculino");
        private static readonly Sexo Feminino = new Sexo(3, "Feminino");

        protected Sexo() { }
        public Sexo(int id, string nome)
            : base(id, nome)
        {
        }

        public static IEnumerable<Sexo> List()
        {
            return new[] { Masculino, Feminino, NaoInformado };
        }

        public static Sexo BuscarPeloNome(string nome)
        {
            var situacao = List()
                .SingleOrDefault(n => String.Equals(n.Name, nome, StringComparison.CurrentCultureIgnoreCase));
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para sexo: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }

        public static Sexo BuscarPeloCodigo(int id)
        {
            var situacao = List()
                .SingleOrDefault(c => c.Id == id);
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para sexo: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }
    }
}
