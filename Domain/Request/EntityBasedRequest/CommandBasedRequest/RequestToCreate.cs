using MediatR;

namespace XSwift.Domain
{
    public abstract class RequestToCreate<TEntity, IReturnedType> :
        BaseCommandRequest<TEntity>, IRequest<IReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            entity.Create();
        }
    }
}
