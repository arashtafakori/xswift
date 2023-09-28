using MediatR;

namespace XSwift.Domain
{
    public abstract class RequestToUpdate<TEntity> :
        BaseCommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public override void Resolve(TEntity entity)
        {
            entity.Update();
        }
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            entity.Update();
        }
    }
}
