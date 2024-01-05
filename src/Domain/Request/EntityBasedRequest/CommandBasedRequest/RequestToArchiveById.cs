using System.Linq.Expressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a request to archive an entity of a specific type by its identifier.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the archive request.</typeparam>
    /// <typeparam name="IdType">The type of the identifier for the entity.</typeparam>
    public abstract class RequestToArchiveById<TEntity, IdType> :
        RequestToArchive<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestToArchiveById{TEntity, IdType}"/> class.
        /// </summary>
        /// <param name="id">The identifier of the entity to be archived.</param>
        public RequestToArchiveById(IdType id) 
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the identifier of the entity to be archived.
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
        /// Sets the identifier of the entity to be archived.
        /// </summary>
        /// <param name="value">The value to set as the identifier.</param>
        /// <returns>The current instance of the archive request for fluent chaining.</returns>
        public virtual RequestToArchiveById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
