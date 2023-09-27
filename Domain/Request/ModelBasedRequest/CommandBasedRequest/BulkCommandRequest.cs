using MediatR;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class BulkCommandRequest<TEntity, TModel>
        : QueryListRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public virtual void Resolve(List<TModel> items)
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(List<TModel> items, IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
