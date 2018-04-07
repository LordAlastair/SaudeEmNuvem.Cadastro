using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    //Possível migração para o módulo de autenticação...
    public class Email : ValueObject
    {
        public string EnderecoEmail { get; }
        public bool Principal { get; }
        public bool Confirmado { get; }

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
