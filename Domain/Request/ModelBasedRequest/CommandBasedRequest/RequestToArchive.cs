using MediatR;

namespace XSwift.Domain
{
    public abstract class RequestToArchive<TEntity> :
        BaseCommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public override void Resolve(TEntity entity)
        {
            entity.Archive();
        }
        public override void Resolve(List<TEntity> entities)
        {
            entities.ForEach(entity => { entity.Archive(); });
        }
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            await new InvariantState()
                .DefineAnInvariant(
                result: entity.Deleted != 0,
                issue: new AnEntityWasArchivedSoArchivingItAgainIsNotPossible(typeof(TEntity).Name))
                .CheckAsync(mediator);

            entity.Archive();
        }
    }
}
