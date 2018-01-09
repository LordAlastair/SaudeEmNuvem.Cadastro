using System;

namespace SaudeEmNuvem.Cadastro.Domain.Exceptions
{
    public class CadastroDomainException : Exception
    {
        public CadastroDomainException() { }
        public CadastroDomainException(string mensagem) : base(mensagem) { }
        public CadastroDomainException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
