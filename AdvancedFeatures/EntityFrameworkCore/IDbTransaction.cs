using Microsoft.EntityFrameworkCore.Storage;

namespace Artaco.Infrastructure.CoreX
{
    public interface IDbTransaction
    {
        Task<IDbContextTransaction> BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}