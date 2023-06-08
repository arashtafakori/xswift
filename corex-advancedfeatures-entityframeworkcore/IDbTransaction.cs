using Microsoft.EntityFrameworkCore.Storage;

namespace CoreX.AdvancedFeatures.EntityFrameworkCore
{
    public delegate void DbUpdateConcurrencyConflictOccurred();

    public interface IDbTransaction
    {
        Task<IDbContextTransaction> BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync(
            bool concurrencyCheck = true,
            DbUpdateConcurrencyConflictOccurred? toCheckConcurrencyConflictOccurred = null);
    }
}