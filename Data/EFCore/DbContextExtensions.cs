using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreX.Structure
{
    public static class DbContextExtensions
    {
       public static async Task<TEntity> Single<TEntity>(
       this DbContext context,
       Expression<Func<TEntity, bool>>? where = null,
       Expression<Func<TEntity, object>>? include = null,
       bool? tracking = false,
       bool evenDeleted = false,
       bool throwExceptionIfTheEntityNouFound = true)
       where TEntity : Model
        {
            var query = EFCoreUtils.GetQuery(context,
                where: where,
                include: include,
                tracking: tracking,
                evenDeleted: evenDeleted);


            var entity = await query.SingleOrDefaultAsync(where!);
            if (throwExceptionIfTheEntityNouFound)
            {
                if (entity == null)
                    throw new EntityWasNotFoundException();
            }

            return entity!;
        }

        public static async Task<TEntity> Find<TEntity>(
            this DbContext context,
            bool throwExceptionIfTheEntityNouFound = true,
            params object[] KeyValues
            ) where TEntity : Model
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();
            var entity = (await _dbSet.FindAsync(KeyValues))!;
      
            if (throwExceptionIfTheEntityNouFound)
            {
                if (entity == null)
                    throw new EntityWasNotFoundException();
            }

            return entity;
        }

        public static async Task<IEnumerable<TEntity>> ToList<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? tracking = false,
            bool evenDeleted = true)
            where TEntity : Model
        {
            var query = EFCoreUtils.GetQuery(context,
                where: where,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                tracking: tracking,
                evenDeleted: evenDeleted);

            return await query.ToListAsync();
        }

        public static async Task ThrowIfAnEntityFound<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>> where) where TEntity : Model
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable().AsNoTracking();

            if (await query.AsNoTracking().AnyAsync(where))
                throw new EntityWasFoundException();
        }
    }
}
