using MediatR;

namespace XSwift.Domain
{
    public abstract class ArchivingRequestById<TRequest, TEntity, IdType> :
        BaseCommandRequestById<TEntity, IdType>
        where TRequest : BaseCommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public ArchivingRequestById(IdType id) : base(id)
        {
        }

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
