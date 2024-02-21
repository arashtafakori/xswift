namespace XSwift.Domain
{
    /// <summary>
    /// Represents an interface for entities that support archiving.
    /// </summary>
    public interface IArchivable
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is marked as isArchived (soft delete).
        /// </summary>
        public bool IsArchived { get ; set; }
    }
}
