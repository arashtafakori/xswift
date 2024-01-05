using System.Linq.Expressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to restore an archived entity of a specific type by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the restore request.</typeparam>
    /// <typeparam name="IdType">The type of the identifier for the entity.</typeparam>
    public abstract class RequestToRestoreById<TEntity, IdType> :
        RequestToRestore<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToRestoreById{TEntity, IdType}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity to be restored.</param>
        public RequestToRestoreById(IdType id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier of the entity to be restored.
        /// </summary>
        public IdType Id { get; private set; }

        /// <summary>
        /// Overrides the base method to provide an identification expression based on the entity's identifier.
        /// </summary>
        /// <returns>The identification expression for the entity.</returns>
        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        /// <summary>
        /// Sets the identifier of the entity to be restored.
        /// </summary>
        /// <param name="value">The value to set as the identifier.</param>
        /// <returns>The current instance of the restore request for fluent chaining.</returns>
        public virtual RequestToRestoreById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
