using MediatR;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class QueryListRequest<TEntity, TReturnedType>
        : QueryRequest<TEntity>, IRequest<TReturnedType>
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
        public async virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public async virtual Task NextAsync(IMediator mediator, TReturnedType returnedItems)
        {
            throw new NotImplementedException();
        }
    }
}
