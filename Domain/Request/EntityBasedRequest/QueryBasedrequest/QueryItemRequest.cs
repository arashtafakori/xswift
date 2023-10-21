using MediatR;

namespace XSwift.Domain
{
    public abstract class QueryItemRequest<TEntity, TReturnedType>
        : QueryRequest<TEntity>, IRequest<TReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
        public async virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public async virtual Task NextAsync(IMediator mediator, TReturnedType returnItem)
        {
            throw new NotImplementedException();
        }
    }
}
