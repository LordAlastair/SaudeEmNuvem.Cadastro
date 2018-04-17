using FluentValidation;
using SaudeEmNuvem.Cadastro.API.Application.Commands;

namespace SaudeEmNuvem.Cadastro.API.Application.Validations
{
    public class IdentificadorDeComandosValidator
        : AbstractValidator<IdentificadorDeComandos<CriarCadastroCommand, bool>>
    {
        public IdentificadorDeComandosValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
