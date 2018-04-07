using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Pessoa : ValueObject
    {
        public string Nome { get; }
        public string Apelido { get; }
        public string NomeMae { get; }
        public string NomePai { get; }
        public DateTime? DataNascimento { get; }

        protected Pessoa() { }

        public Pessoa(string nome, string apelido, string nomeMae, string nomePai, DateTime? dataNascimento)
        {
            Nome = nome;
            Apelido = apelido;
            NomeMae = nomeMae;
            NomePai = nomePai;
            DataNascimento = dataNascimento;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Nome;
            yield return Apelido;
            yield return NomeMae;
            yield return NomePai;
            yield return DataNascimento;
        }
    }
}
