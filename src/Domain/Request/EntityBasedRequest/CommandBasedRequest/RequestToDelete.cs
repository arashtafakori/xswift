using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to delete an entity of a specific type.
    /// Typically a request to delete an entity is used to delete the entity physically. If the purpose is archiving, the request should be defined as the archiving.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the delete request.</typeparam>
    public abstract class RequestToDelete<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the delete request and marks the associated entity as deleted.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the delete request.</param>
        /// <param name="entity">The associated entity to be deleted.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Delete the entity
            entity.Delete();
        }
    }
}
