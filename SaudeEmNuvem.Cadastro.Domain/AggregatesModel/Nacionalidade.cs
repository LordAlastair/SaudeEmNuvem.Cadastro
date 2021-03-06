﻿using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class Nacionalidade : Enumeration
    {
        public static Nacionalidade NaoInformado = new Nacionalidade(0, "Não Informado");
        public static Nacionalidade Brasileiro = new Nacionalidade(1, "Brasileiro");
        public static Nacionalidade Naturalizado = new Nacionalidade(2, "Naturalizado");
        public static Nacionalidade Estrangeiro = new Nacionalidade(3, "Estrangeiro");

        protected Nacionalidade() { }
        public Nacionalidade(int id, string nome)
            : base(id, nome) { }

        public static IEnumerable<Nacionalidade> List()
        {
            return new[] { Brasileiro, Naturalizado, Estrangeiro, NaoInformado };
        }

        public static Nacionalidade BuscarPeloNome(string nome)
        {
            var situacao = List()
                .SingleOrDefault(n => String.Equals(n.Name, nome, StringComparison.CurrentCultureIgnoreCase));
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para nacionalidade: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }

        public static Nacionalidade BuscarPeloCodigo(int id)
        {
            var situacao = List()
                .SingleOrDefault(c => c.Id == id);
            if (situacao == null)
            {
                throw new ArgumentException($"Valores possiveis para nacionalidade: {String.Join(",", List().Select(s => s.Name))}");
            }

            return situacao;
        }
    }
}
