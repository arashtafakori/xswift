﻿using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base entity with common properties and methods for entities in the domain model.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseEntity<TEntity> : ISoftDelete
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is marked as deleted (soft delete). The zero value means not deleted.
        /// </summary>
        public byte Deleted { get; set; } = 0;

        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last modified.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Creates the entity, setting the creation and modification dates.
        /// </summary>
        public virtual void Create()
        {
            CreatedDate = ModifiedDate = DateTimeHelper.UtcNow;
        }

        /// <summary>
        /// Updates the entity, setting the modification date.
        /// </summary>
        public virtual void Update()
        {
            ModifiedDate = DateTimeHelper.UtcNow;
        }

        /// <summary>
        /// Archives the entity, setting the modification date.
        /// </summary>
        public virtual void Archive()
        {
            ModifiedDate = DateTimeHelper.UtcNow;
        }

        /// <summary>
        /// Restores the entity, setting the modification date.
        /// </summary>
        public virtual void Restore()
        {
            ModifiedDate = DateTimeHelper.UtcNow;
        }

        /// <summary>
        /// Deletes the entity (soft delete).
        /// </summary>
        public virtual void Delete()
        {
        }

        /// <summary>
        /// Provides a condition for ensuring the uniqueness of the entity.
        /// </summary>
        /// <returns>A condition property specifying uniqueness criteria, or null if uniqueness is not required.</returns>
        public virtual ConditionProperty<TEntity>? Uniqueness() { return null; }
    }
}