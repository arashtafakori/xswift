using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to update an entity of a specific type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the update request.</typeparam>
    public abstract class RequestToUpdate<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the update request and updates the associated entity.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the update request.</param>
        /// <param name="entity">The associated entity to be updated.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Update the entity
            entity.Update();
        }
    }
}
