using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to restore an archived entity of a specific type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the restore request.</typeparam>
    public abstract class RequestToRestore<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the restore request and restores the associated entity.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the restore request.</param>
        /// <param name="entity">The associated entity to be restored.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Check if the entity is not deleted before attempting to restore
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                result: entity.Deleted == 0,
                issue: new NoEntityWasArchivedSoRestoringItIsNotPossible(typeof(TEntity).Name))
                .AssestAsync(mediator);

            // Restore the entity
            entity.Restore();
        }
    }
}
