using Microsoft.EntityFrameworkCore.Storage;

namespace CoreX.Structure
{
    public interface IDbTransaction
    {
        Task<IDbContextTransaction> Begin();
        Task Commit();
        Task Rollback();
        Task<int> SaveChanges();
    }
}