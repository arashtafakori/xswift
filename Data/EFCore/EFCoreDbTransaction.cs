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

        public async Task<IDbContextTransaction> BeginAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
