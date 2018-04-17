using MediatR;
using SaudeEmNuvem.Cadastro.Infrastructure.Idempotency;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.API.Application.Commands
{
    public class IdentificadorDeComandosHandler<T, TR> : AsyncRequestHandler<IdentificadorDeComandos<T, TR>, TR>
        where T : IRequest<TR>
    {
        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;

        public IdentificadorDeComandosHandler(IMediator mediator, IRequestManager requestManager)
        {
            _mediator = mediator;
            _requestManager = requestManager;
        }

        /// <summary>
        /// Creates the result value to return if a previous request was found
        /// </summary>
        /// <returns></returns>
        protected virtual TR CreateResultForDuplicateRequest()
        {
            return default(TR);
        }

        /// <summary>
        /// This method handles the command. It just ensures that no other request exists with the same ID, and if this is the case
        /// just enqueues the original inner command.
        /// </summary>
        /// <param name="message">IdentifiedCommand which contains both original command & request ID</param>
        /// <returns>Return value of inner command or default value if request same ID was found</returns>
        public async Task<TR> Handle(IdentificadorDeComandos<T, TR> message)
        {
            var alreadyExists = await _requestManager.ExistAsync(message.Id);
            if (alreadyExists)
            {
                return CreateResultForDuplicateRequest();
            }

            await _requestManager.CreateRequestForCommandAsync<T>(message.Id);

            var result = await _mediator.Send(message.Command);

            return result;
        }
    }
}
