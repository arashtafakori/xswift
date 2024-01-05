using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to determine if any entities of a specific type exist based on the specified criteria.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    public abstract class AnyRequest<TEntity>
        : QueryRequest<TEntity>, IRequest<bool>
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
        /// Asynchronously handles the next step in the request processing using the provided mediator and the result.
        /// </summary>
        /// <param name="mediator">The mediator used to handle the next step.</param>
        /// <param name="result">The result of the request resolution.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task NextAsync(IMediator mediator, bool result)
        {
            throw new NotImplementedException();
        }
    }
}
