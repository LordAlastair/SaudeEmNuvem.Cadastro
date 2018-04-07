using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Naturalizacao : ValueObject
    {
        public string Numero { get; }
        public string Portaria { get; }
        public string Pais { get; }
        public DateTime DataEntrada { get; }
        public DateTime? DataNaturalizacao { get; }

        protected Naturalizacao() { }

        public Naturalizacao(string numero, string portaria, string pais, DateTime dataEntrada, DateTime? dataNaturalizacao)
        {
            Numero = numero;
            Portaria = portaria;
            Pais = pais;
            DataEntrada = dataEntrada;
            DataNaturalizacao = dataNaturalizacao;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Numero;
            yield return Portaria;
            yield return Pais;
            yield return DataEntrada;
            yield return DataNaturalizacao;
        }
    }
}
