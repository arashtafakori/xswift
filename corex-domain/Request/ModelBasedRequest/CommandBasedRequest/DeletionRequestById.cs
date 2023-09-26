using MediatR;

namespace CoreX.Domain
{
    public abstract class DeletionRequestById<TRequest, TEntity, IdType> :
        BaseCommandRequestById<TEntity, IdType>
        where TRequest : BaseCommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public DeletionRequestById(IdType id) : base(id)
        {
        }
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
