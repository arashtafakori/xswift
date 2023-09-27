using MediatR;

namespace XSwift.Domain
{
    public abstract class RestorationRequestById<TRequest, TEntity, IdType> :
        BaseCommandRequestById<TEntity, IdType>
        where TRequest : BaseCommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public RestorationRequestById(IdType id) : base(id)
        {
        }
        public override void Resolve(TEntity entity)
        {
            entity.Restore();
        }
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            await new InvariantState()
                .DefineAnInvariant(
                result: entity.Deleted == 0,
                issue: new NoEntityWasArchivedSoRestoringItIsNotPossible(typeof(TEntity).Name))
                .CheckAsync(mediator);

            entity.Restore();
        }
    }
}
