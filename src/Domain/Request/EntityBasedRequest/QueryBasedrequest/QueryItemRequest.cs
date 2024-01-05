using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to retrieve a specific item of a certain type and return a result.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    /// <typeparam name="TReturnedType">The type of the result returned by the request.</typeparam>
    public abstract class QueryItemRequest<TEntity, TReturnedType>
        : QueryRequest<TEntity>, IRequest<TReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously resolves the request using the provided mediator.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the request.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously handles the next step in the request processing using the provided mediator and the returned item.
        /// </summary>
        /// <param name="mediator">The mediator used to handle the next step.</param>
        /// <param name="returnItem">The returned item from the previous step.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task NextAsync(IMediator mediator, TReturnedType returnItem)
        {
            throw new NotImplementedException();
        }
    }
}
