using System;
using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Pessoa : ValueObject
    {
        public string Nome { get; private set; }
        public string Apelido { get; private set; }
        public string NomeMae { get; private set; }
        public string NomePai { get; private set; }
        public DateTime? DataNascimento { get; private set; }

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
