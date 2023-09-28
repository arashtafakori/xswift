using MediatR;

namespace XSwift.Domain
{
    public abstract class RequestToRestore<TEntity> :
        BaseCommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
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
