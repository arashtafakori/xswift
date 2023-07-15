using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkCore.CoreX
{
    public static class DbContextExtensions
    {
        public static async Task<List<TEntity>> GetEntitiesAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool? includedArchivedEntities = false,
            bool throwExceptionIfEntityWasNotFound = false)
            where TEntity : BaseEntity
        {
            var query = context.GetQuery(
                condition: condition,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                trackingMode: trackingMode,

                includedArchivedEntities: includedArchivedEntities);

            var entities = await query.ToListAsync();

            if (entities.Count == 0)
            {
                if (throwExceptionIfEntityWasNotFound)
                {
                    new LogicalState
                    {
                        new EntityWasNotFoundIssue(typeof(TEntity).Name)
                    }.Throw();
                }
            }

            return entities;
        }

        public static async Task<TEntity?> GetEntityAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool? includedArchivedEntities = false,
            bool throwExceptionIfEntityWasNotFound = false)
            where TEntity : BaseEntity
        {
            var query = context.GetQuery(
                condition: condition,
                include: include,
                trackingMode: trackingMode,
                includedArchivedEntities: includedArchivedEntities);

            var entities = await query.ToListAsync();

            if(entities.Count == 0)
            {
                if (throwExceptionIfEntityWasNotFound)
                {
                    new LogicalState
                    {
                        new EntityWasNotFoundIssue(typeof(TEntity).Name)
                    }.Throw();
                }
                else
                {
                    return null;
                }
            }

            return entities[0];
        }

        public static async Task ThrowIfTheEntityWithThisSpecificationHasAlreadyBeenExisted<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>> condition) 
            where TEntity : BaseEntity
        {
            if (await context.AnyAsync(condition))
            {
                new LogicalState
                    {
                        new TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue(
                            typeof(TEntity).Name)
                    }.Throw();
            }
        }

        public static async Task<bool> AnyAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? condition,
            Expression<Func<TEntity, object>>? include = null,
            bool includedArchivedEntities = false)
            where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable().AsNoTracking();

            if (includedArchivedEntities)
                query = query.IgnoreQueryFilters();

            if (include != null)
                query = query.Include(include);

            if (await query.AnyAsync(condition!))
                return true;

            return false;
        }

        public static IQueryable<TEntity> GetQuery<TEntity>(this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool? includedArchivedEntities = false) 
            where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable();

            if ((bool)!trackingMode!)
                query = query.AsNoTracking();

            if ((bool)includedArchivedEntities!)
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
