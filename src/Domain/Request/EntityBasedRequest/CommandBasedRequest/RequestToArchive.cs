using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to archive an entity of a specific type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the archive request.</typeparam>
    public abstract class RequestToArchive<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the archive request, checks pre-archive invariants,
        /// and archives the associated entity.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the archive request.</param>
        /// <param name="entity">The associated entity to be archived.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Check pre-archive invariants before archiving the entity
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                result: entity.IsArchived,
                issue: new AnEntityWasArchivedSoArchivingItAgainIsNotPossible(typeof(TEntity).Name))
                .AssestAsync(mediator);

            // Archive the entity
            entity.Archive();
        }
    }
}
