using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Telefone : ValueObject
    {
        //Outro candidato para o módulo de autenticação
        public int DDD { get; }
        public string Numero { get; }
        public TipoTelefone TipoTelefone { get; }

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
