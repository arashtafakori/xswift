using MediatR;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class QueryListRequest<TEntity>
        : QueryRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public override Expression<Func<TEntity, object>>? OrderBy()
        {
            return x => x.CreatedDate;
        }
        public override Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return x => x.CreatedDate;
        }
    }
}
