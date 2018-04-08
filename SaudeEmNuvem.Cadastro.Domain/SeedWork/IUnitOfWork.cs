using System;
using System.Threading;
using System.Threading.Tasks;

namespace SaudeEmNuvem.Cadastro.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);
    }
}
