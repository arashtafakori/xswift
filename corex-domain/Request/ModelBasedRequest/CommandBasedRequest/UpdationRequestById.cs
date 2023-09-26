using MediatR;

namespace CoreX.Domain
{
    public abstract class UpdationRequestById<TRequest, TEntity, IdType> :
        BaseCommandRequestById<TEntity, IdType>
        where TRequest : BaseCommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public UpdationRequestById(IdType id) : base(id)
        {
        }

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
