using System;
using FluentValidation;
using SaudeEmNuvem.Cadastro.API.Application.Commands;

namespace SaudeEmNuvem.Cadastro.API.Application.Validations
{
    public class CriarCadastroCommandValidator : AbstractValidator<CriarCadastroCommand>
    {
        public CriarCadastroCommandValidator()
        {
            RuleFor(command => command.Nome).NotEmpty().Length(3, 50);
            RuleFor(command => command.Apelido).Length(3, 50);
            RuleFor(command => command.NomeMae).Length(3, 50);
            RuleFor(command => command.NomePai).Length(3, 50);
            RuleFor(command => command.DataNascimento).Must(DataMaiorQueHoje).WithMessage("Data de Nascimento maior que hoje!");
            RuleFor(command => command.MunicipioNascimento).Length(5, 25); 
            RuleFor(command => command.PaisNascimento).Length(3, 50);
            RuleFor(command => command.Nomade); 
            RuleFor(command => command.NumeroNaturalizacao); 
            RuleFor(command => command.Portaria);
            RuleFor(command => command.PaisOrigem).Length(3, 50);
            RuleFor(command => command.DataEntradaPais).Must(DataMaiorQueHoje).WithMessage("Data de Nascimento maior que hoje!");
            RuleFor(command => command.Cep);
            RuleFor(command => command.NumeroEndereco);
            RuleFor(command => command.ChaveNaturalEtiniaIndigena);
            RuleFor(command => command.Etnia);
            RuleFor(command => command.Medico).Length(3, 50); 
            RuleFor(command => command.HorarioObito).Must(DataMaiorQueHoje).WithMessage("Data de Nascimento maior que hoje!");
            RuleFor(command => command.DescricaoObito).Length(3, 500);
            RuleFor(command => command.Nacionalidade);
            RuleFor(command => command.TipoSanguineo);
            RuleFor(command => command.Cor);
            RuleFor(command => command.Sexo);
            RuleFor(command => command.TipoSanguineo);
        }

        private static bool DataMaiorQueHoje(DateTime data)
        {
            return data <= DateTime.UtcNow;
        }
    }
}
