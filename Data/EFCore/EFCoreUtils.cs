using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreX.Structure
{
    public static class EFCoreUtils
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(
             DbContext context,
             Expression<Func<TEntity, bool>>? where = null,
             Expression<Func<TEntity, object>>? orderBy = null,
             Expression<Func<TEntity, object>>? orderByDescending = null,
             Expression<Func<TEntity, object>>? include = null,
             bool? tracking = false,
             bool evenDeleted = true) where TEntity : class
        {
            DbSet<TEntity> _dbSet = context.Set<TEntity>();

            var query = _dbSet.AsQueryable();

            if ((bool)!tracking!)
                query = query.AsNoTracking();

            if (evenDeleted)
                query = query.IgnoreQueryFilters();

            if (where != null)
                query = query.Where(where);

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
