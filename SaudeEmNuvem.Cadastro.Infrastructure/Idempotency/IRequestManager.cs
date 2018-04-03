using System;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.Infrastructure.Idempotency
{
    public interface IRequestManager
    {
        Task<bool> ExistAsync(Guid id);

        Task CreateRequestForCommandAsync<T>(Guid id);
    }
}
