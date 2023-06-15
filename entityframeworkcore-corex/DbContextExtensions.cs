using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkCore.CoreX
{
    public static class DbContextExtensions
    {
       public static async Task<TEntity> SingleAsync<TEntity>(
       this DbContext context,
       Expression<Func<TEntity, bool>>? condition = null,
       Expression<Func<TEntity, object>>? include = null,
       bool? trackingMode = false,
       bool alsoTheDeletedOnes = false,
       bool throwExceptionProvidedEntityWasNotFound = true)
       where TEntity : BaseEntity
        {
            var query = context.GetQuery(
                condition: condition,
                include: include,
                trackingMode: trackingMode,
                alsoTheDeletedOnes: alsoTheDeletedOnes);


            var entity = await query.SingleOrDefaultAsync(condition!);
            if (throwExceptionProvidedEntityWasNotFound)
                if (entity == null)
                    throw new EntityWasNotFoundException();

            return entity!;
        }

        public static async Task<TEntity> FindAsync<TEntity>(
            this DbContext context,
            bool throwExceptionIfEntityWasNotFound = false,
            params object[] KeyValues
            ) where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();
            var entity = (await _dbSet.FindAsync(KeyValues))!;
      
            if (throwExceptionIfEntityWasNotFound)
                if (entity == null)
                    throw new EntityWasNotFoundException();

            return entity;
        }

        public static async Task<IEnumerable<TEntity>> ToListAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool alsoTheDeletedOnes = true)
            where TEntity : BaseEntity
        {
            var query = context.GetQuery(
                condition: condition,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                trackingMode: trackingMode,
                alsoTheDeletedOnes: alsoTheDeletedOnes);

            return await query.ToListAsync();
        }

        public static async Task ThrowEntityWasNotFound<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>> condition) where TEntity : BaseEntity
        {
            if (!await context.ToCheckIfTheEntityWithTheIdentificationsAlreadyExists(condition))
                throw new EntityWasNotFoundException();
        }

        public static async Task ThrowIfTheEntityWithTheIdentificationsAlreadyExists<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>> condition) where TEntity : BaseEntity
        {
             if (await context.ToCheckIfTheEntityWithTheIdentificationsAlreadyExists(condition))
                throw new EntityWithTheIdentificationsAlreadyExistsException();
        }

        public static async Task<bool> ToCheckIfTheEntityWithTheIdentificationsAlreadyExists<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>> condition) where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable().AsNoTracking();

            if (await query.AsNoTracking().AnyAsync(condition))
                return true;

            return false;
        }

        public static IQueryable<TEntity> GetQuery<TEntity>(this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool alsoTheDeletedOnes = true) where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable();

            if ((bool)!trackingMode!)
                query = query.AsNoTracking();

            if (alsoTheDeletedOnes)
                query = query.IgnoreQueryFilters();

            if (condition != null)
                query = query.Where(condition);

            if (orderBy != null)
                query = query.OrderByDescending(orderBy);

            if (orderByDescending != null)
                query = query.OrderByDescending(orderByDescending);

            if (include != null)
                query = query.Include(include);

            return query;
        }
    }
}
