using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    //Possível migração para o módulo de autenticação...
    public class Email : ValueObject
    {
        public string EnderecoEmail { get; private set; }
        public bool Principal { get; private set; }
        public bool Confirmado { get; private set; }

        protected Email() { }
        public Email(string enderecoEmail, bool principal, bool confirmado)
        {
            EnderecoEmail = enderecoEmail;
            Principal = principal;
            Confirmado = confirmado;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EnderecoEmail;
            yield return Principal;
            yield return Confirmado;
        }
    }
}