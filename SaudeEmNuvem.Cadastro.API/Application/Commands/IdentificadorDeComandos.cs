using MediatR;
using System;

namespace SaudeEmNuvem.Cadastro.API.Application.Commands
{
    public class IdentificadorDeComandos<T, TR> : IRequest<TR> where T : IRequest<TR>
    {
        public T Command { get; }
        public Guid Id { get; }
        public IdentificadorDeComandos(T command, Guid id)
        {
            Command = command;
            Id = id;
        }
    }
}
