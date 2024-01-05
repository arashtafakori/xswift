using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to create an entity of a specific type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the create request.</typeparam>
    /// <typeparam name="IReturnedType">The type of the returned value from the create request.</typeparam>
    public abstract class RequestToCreate<TEntity, IReturnedType> :
        BaseCommandRequest<TEntity>, IRequest<IReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the create request and initializes the creation of the associated entity.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the create request.</param>
        /// <param name="entity">The associated entity to be created.</param>
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            // Initialize the creation of the entity
            entity.Create();
        }
    }
}
