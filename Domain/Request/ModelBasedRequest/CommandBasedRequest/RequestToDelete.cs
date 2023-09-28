using MediatR;

namespace XSwift.Domain
{
    public abstract class RequestToDelete<TEntity> :
        BaseCommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public override void Resolve(TEntity entity)
        {
            entity.Delete();
        }
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            entity.Delete();
        }
    }
}
