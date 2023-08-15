using MediatR;

namespace CoreX.Domain
{
    public abstract class AnyRequest<TEntity> :
        ReadonlyRetrivalEntityRequest<TEntity> 
        where TEntity : BaseEntity
    {
        public virtual void Resolve()
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
