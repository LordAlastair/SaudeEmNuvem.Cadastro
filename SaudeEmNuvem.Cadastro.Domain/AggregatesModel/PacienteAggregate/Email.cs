using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    //Possível migração para o módulo de autenticação...
    public class Email : ValueObject
    {
        public string Endereco { get; }
        public bool Principal { get; }
        public bool Confirmado { get; }

        protected Email() { }
        public Email(string enderecoEmail, bool principal)
        {
            Endereco = enderecoEmail;
            Principal = principal;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Endereco;
            yield return Principal;
            yield return Confirmado;
        }
    }
}
