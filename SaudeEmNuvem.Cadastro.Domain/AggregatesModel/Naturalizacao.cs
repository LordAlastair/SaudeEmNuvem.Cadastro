using System;
using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class Naturalizacao : ValueObject
    {
        public string Numero { get; private set; }
        public string Portaria { get; private set; }
        public string Pais { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public DateTime? DataNaturalizacao { get; private set; }

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