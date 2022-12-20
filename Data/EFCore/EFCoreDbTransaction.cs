using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoreX.Structure
{
    public abstract class EFCoreDbTransaction : IDbTransaction
    {
        private readonly DbContext _context;

        public EFCoreDbTransaction(DbContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> Begin()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
