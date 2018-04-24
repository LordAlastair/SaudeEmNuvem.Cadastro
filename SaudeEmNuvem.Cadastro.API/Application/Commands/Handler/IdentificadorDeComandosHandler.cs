using System.Threading;
using MediatR;
using SaudeEmNuvem.Cadastro.Infrastructure.Idempotency;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.Commands.Handler
{
    public class IdentificadorDeComandosHandler<T, TR> : IRequestHandler<IdentificadorDeComandos<T, TR>, TR>
        where T : IRequest<TR>
    {
        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;

        public IdentificadorDeComandosHandler(IMediator mediator, IRequestManager requestManager)
        {
            _mediator = mediator;
            _requestManager = requestManager;
        }

        protected virtual TR RespostaParaRequisicaoDuplicada()
        {
            return default(TR);
        }

        public async Task<TR> Handle(IdentificadorDeComandos<T, TR> message, CancellationToken cancellationToken)
        {
            var alreadyExists = await _requestManager.ExistAsync(message.Id);
            if (alreadyExists)
            {
                return RespostaParaRequisicaoDuplicada();
            }

            await _requestManager.CreateRequestForCommandAsync<T>(message.Id);

            var result = await _mediator.Send(message.Command, cancellationToken);

            return result;
        }
    }
}
