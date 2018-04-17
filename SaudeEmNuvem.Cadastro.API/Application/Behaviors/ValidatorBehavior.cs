using FluentValidation;
using MediatR;
using SaudeEmNuvem.Cadastro.Domain.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;
        public ValidatorBehavior(IValidator<TRequest>[] validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new CadastroDomainException(
                    $"Comando com erros de validação para o tipo  {typeof(TRequest).Name}", new ValidationException("Exceção de validação", failures));
            }

            var response = await next();
            return response;
        }
    }
}
