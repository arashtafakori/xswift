using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkCore.CoreX.Datastore
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// If the limit parameter is zero,
        /// it means that the rest of the records,
        /// which exist after the offset will be retrieved.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="condition"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderByDescending"></param>
        /// <param name="include"></param>
        /// <param name="trackingMode"></param>
        /// <param name="evenArchivedData"></param>
        /// <param name="throwExceptionIfEntityWasNotFound"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static async Task<List<TEntity>> GetEntitiesAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool? evenArchivedData = false,
            bool throwExceptionIfEntityWasNotFound = false,
            int offset = 0,
            int limit = 0)
            where TEntity : BaseEntity
        {
            var query = context.GetQuery(
                condition: condition,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                trackingMode: trackingMode,
                evenArchivedData: evenArchivedData);

            query = query.Skip(offset);

            if (limit != 0)
                query = query.Take(limit);

            var entities = await query.ToListAsync();

            if (entities.Count == 0)
            {
                if (throwExceptionIfEntityWasNotFound)
                {
                    new LogicalState
                    {
                        new EntityWasNotFound(typeof(TEntity).Name)
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
            bool? evenArchivedData = false,
            bool throwExceptionIfEntityWasNotFound = false)
            where TEntity : BaseEntity
        {
            var query = context.GetQuery(
                condition: condition,
                include: include,
                trackingMode: trackingMode,
                evenArchivedData: evenArchivedData);

            var entities = await query.ToListAsync();

            if(entities.Count == 0)
            {
                if (throwExceptionIfEntityWasNotFound)
                {
                    new LogicalState
                    {
                        new EntityWasNotFound(typeof(TEntity).Name)
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
                        new AnEntityWithThisSpecificationHasAlreadyBeenExisted(
                            typeof(TEntity).Name)
                    }.Throw();
            }
        }

        public static async Task<bool> AnyAsync<TEntity>(
            this DbContext context,
            Expression<Func<TEntity, bool>>? condition,
            Expression<Func<TEntity, object>>? include = null,
            bool evenArchivedData = false)
            where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable().AsNoTracking();

            if (evenArchivedData)
                query = query.IgnoreQueryFilters();

            if (include != null)
                query = query.Include(include);

            return await query.AnyAsync(condition!);
        }

        public static IQueryable<TEntity> GetQuery<TEntity>(this DbContext context,
            Expression<Func<TEntity, bool>>? condition = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            Expression<Func<TEntity, object>>? orderByDescending = null,
            Expression<Func<TEntity, object>>? include = null,
            bool? trackingMode = false,
            bool? evenArchivedData = false) 
            where TEntity : BaseEntity
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable();

            if ((bool)!trackingMode!)
                query = query.AsNoTracking();

            if ((bool)evenArchivedData!)
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
