using MediatR;

namespace XSwift.Domain
{
    public abstract class CreationRequest<TRequest, TEntity> :
        BaseCommandRequest<TEntity>
        where TRequest : BaseCommandRequest<TEntity> 
        where TEntity : BaseEntity<TEntity>
    {
        public override void Resolve(TEntity entity)
        {
            entity.Create();
        }
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            entity.Create();
        }
    }
}
