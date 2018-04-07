using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Endereco : ValueObject
    {
        // ReSharper disable once InconsistentNaming
        public string CEP { get; }
        public int Numero { get; }

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
