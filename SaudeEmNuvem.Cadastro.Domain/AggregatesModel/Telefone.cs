using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.SeedWork;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel
{
    public class Telefone : ValueObject
    {
        //Outro candidato para o módulo de autenticação
        public int DDD { get; private set; }
        public string Numero { get; private set; }
        public TipoTelefone TipoTelefone { get; private set; }

        protected Telefone() { }
        public Telefone(int ddd, string numero, TipoTelefone tipoTelefone)
        {
            DDD = ddd;
            Numero = numero;
            TipoTelefone = tipoTelefone;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return DDD;
            yield return Numero;
            yield return TipoTelefone;
        }
    }
}