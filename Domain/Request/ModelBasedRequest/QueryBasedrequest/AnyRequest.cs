using MediatR;

namespace XSwift.Domain
{
    public abstract class AnyRequest<TEntity>
        : QueryRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public virtual void Resolve(bool result)
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(IMediator mediator, bool result)
        {
            throw new NotImplementedException();
        }
    }
}
