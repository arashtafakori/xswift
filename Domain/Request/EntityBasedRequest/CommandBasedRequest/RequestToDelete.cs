using MediatR;

namespace XSwift.Domain
{
    public abstract class RequestToDelete<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            entity.Delete();
        }
    }
}
