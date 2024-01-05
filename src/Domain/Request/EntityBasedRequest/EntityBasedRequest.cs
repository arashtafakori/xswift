using Newtonsoft.Json;
using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for requests associated with a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the request.</typeparam>
    public abstract class EntityBasedRequest<TEntity> :
        BaseRequest
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Gets or sets the expression builder used to construct filter conditions for the request.
        /// </summary>
        [JsonIgnore]
        public ExpressionBuilder<TEntity> WhereExpression { get; private set; } = new ExpressionBuilder<TEntity>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBasedRequest{TEntity}"/> class.
        /// </summary>
        public EntityBasedRequest() 
        {
            InvariantState = new();
        }

        /// <summary>
        /// Gets or sets the invariant state associated with the entity-based request.
        /// </summary>
        [JsonIgnore]
        public InvariantState<TEntity> InvariantState { get; private set; }

        /// <summary>
        /// Provides access to the expression builder for constructing filter conditions.
        /// </summary>
        /// <returns>The expression builder associated with the request.</returns>
        public virtual ExpressionBuilder<TEntity> Where()
        {
            return WhereExpression;
        }
    }
}
