using MediatR;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to retrieve a list of items of a certain type and return a result.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    /// <typeparam name="TReturnedType">The type of the result returned by the request.</typeparam>
    public abstract class QueryListRequest<TEntity, TReturnedType>
        : QueryRequest<TEntity>, IRequest<TReturnedType>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Overrides the base `OrderBy` method to provide the default order by expression.
        /// The default order by expression is based on the modified date.
        /// </summary>
        /// <returns>The order by expression for the request.</returns>
        public override Expression<Func<TEntity, object>>? OrderBy()
        {
            return x => x.ModifiedDate;
        }

        /// <summary>
        /// Overrides the base `OrderByDescending` method to provide the default order by descending expression.
        /// The default order by descending expression is based on the modified date.
        /// </summary>
        /// <returns>The order by descending expression for the request.</returns>
        public override Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return x => x.ModifiedDate;
        }

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
        /// Asynchronously handles the next step in the request processing using the provided mediator and the returned items.
        /// </summary>
        /// <param name="mediator">The mediator used to handle the next step.</param>
        /// <param name="returnedItems">The returned items from the previous step.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task NextAsync(IMediator mediator, TReturnedType returnedItems)
        {
            throw new NotImplementedException();
        }
    }
}
