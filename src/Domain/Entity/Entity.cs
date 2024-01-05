using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base entity with a unique identifier and common properties for entities in the domain model.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="IdType">The type of the unique identifier for the entity.</typeparam>
    public abstract class Entity<TEntity, IdType> :
        BaseEntity<TEntity>
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        [Required]
        [Column(Order = 0)]
        public IdType Id { get; private set; }

        /// <summary>
        /// Sets the unique identifier for the entity.
        /// </summary>
        /// <param name="value">The value to set as the unique identifier.</param>
        public void SetId(IdType value)
        {
            Id = value;
        }
    }
}
