using MediatR;

namespace XSwift.Domain
{
    public abstract class AnyRequest<TEntity>
        : QueryRequest<TEntity>, IRequest<bool>
        where TEntity : BaseEntity<TEntity>
    {
        public async virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public async virtual Task NextAsync(IMediator mediator, bool result)
        {
            throw new NotImplementedException();
        }
    }
}
