﻿using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class TipoDocumento : Enumeration
    {
        private static readonly TipoDocumento Outro = new TipoDocumento(0, "Outro");
        private static readonly TipoDocumento CPF = new TipoDocumento(1, "CPF");
        private static readonly TipoDocumento RG = new TipoDocumento(2, "RG");
        private static readonly TipoDocumento DNV = new TipoDocumento(3, "DNV");
        private static readonly TipoDocumento InscricaoSocial = new TipoDocumento(4, "NIS/PIS/PASEP");

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
