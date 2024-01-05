using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to retrieve a specific item of a certain type by its identifier and return a result.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    /// <typeparam name="IdType">The type of the entity identifier.</typeparam>
    /// <typeparam name="TReturnedType">The type of the result returned by the request.</typeparam>
    public abstract class QueryItemRequestById<TEntity, IdType, TReturnedType>
        : QueryItemRequest<TEntity, TReturnedType>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Gets or sets the identifier of the entity for which the specific item is being requested.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryItemRequestById{TEntity, IdType, TReturnedType}"/> class with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        public QueryItemRequestById(IdType id)
        {
            Id = id; 
        }

        /// <summary>
        /// Sets the identifier of the entity for which the specific item is being requested.
        /// </summary>
        /// <param name="value">The new value for the identifier.</param>
        /// <returns>The current instance of the request for fluent chaining.</returns>
        public virtual QueryItemRequestById<TEntity, IdType, TReturnedType> SetId(IdType value)
        {
            Id = value;

            return this;
        }

        /// <summary>
        /// Overrides the base `Where` method to include a condition for the specified entity identifier.
        /// </summary>
        /// <returns>The expression builder associated with the request.</returns>
        public override ExpressionBuilder<TEntity> Where()
        {
            WhereExpression.And(x => x.Id!.Equals(Id));
            return base.Where();
        }
    }
}
