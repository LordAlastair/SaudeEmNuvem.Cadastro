using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Endereco : ValueObject
    {
        public string CEP { get; private set; }
        public int Numero { get; private set; }

        protected Endereco() { }
        public Endereco(string cep, int numero)
        {
            CEP = cep;
            Numero = numero;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CEP;
            yield return Numero;
        }
    }
}