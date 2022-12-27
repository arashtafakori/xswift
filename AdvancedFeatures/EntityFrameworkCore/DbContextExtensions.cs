using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Artaco.Infrastructure.CoreX
{
    public static class DbContextExtensions
    {
       public static async Task<TEntity> SingleAsync<TEntity>(
       this DbContext context,
       Expression<Func<TEntity, bool>>? where = null,
       Expression<Func<TEntity, object>>? include = null,
       bool? tracking = false,
       bool evenTheDeletedOnes = false,
       bool throwExceptionIfTheEntityNouFound = true)
       where TEntity : BaseEntity
        {
            var query = EFCoreUtils.GetQuery(context,
                where: where,
                include: include,
                tracking: tracking,
                evenTheDeletedOnes: evenTheDeletedOnes);


            var entity = await query.SingleOrDefaultAsync(where!);
            if (throwExceptionIfTheEntityNouFound)
            {
                if (entity == null)
                    throw new TheEntityWasNotFoundException();
            }

            return entity!;
        }

        public static async Task<TEntity> FindAsync<TEntity>(
            this DbContext context,
            bool throwExceptionIfTheEntityNouFound = true,
            params object[] KeyValues
            ) where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();
            var entity = (await _dbSet.FindAsync(KeyValues))!;
      
            if (throwExceptionIfTheEntityNouFound)
            {
                if (entity == null)
                    throw new TheEntityWasNotFoundException();
            }

            return entity;
        }

        public static async Task<IEnumerable<TEntity>> ToListAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? tracking = false,
            bool evenTheDeletedOnes = true)
            where TEntity : BaseEntity
        {
            var query = EFCoreUtils.GetQuery(context,
                where: where,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                tracking: tracking,
                evenTheDeletedOnes: evenTheDeletedOnes);

            return await query.ToListAsync();
        }

        public static async Task ThrowIfTheEntityWasNotFound<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>> where) where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable().AsNoTracking();

            if (!await query.AsNoTracking().AnyAsync(where))
                throw new TheEntityWasNotFoundException();
        }
    }
}
