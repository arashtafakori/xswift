using Microsoft.EntityFrameworkCore.Storage;

namespace CoreX.Structure
{
    public interface IDbTransaction
    {
        Task<IDbContextTransaction> BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}