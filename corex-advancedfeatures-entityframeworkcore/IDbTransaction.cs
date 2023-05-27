using Microsoft.EntityFrameworkCore.Storage;

namespace CoreX.AdvancedFeatures.EntityFrameworkCore
{
    public interface IDbTransaction
    {
        Task<IDbContextTransaction> BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}