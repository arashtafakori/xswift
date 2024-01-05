namespace XSwift.Domain
{
    /// <summary>
    /// Represents an interface for entities that support soft deletion.
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity is marked as deleted (soft delete).
        /// </summary>
        public byte Deleted { get ; set; }
    }
}
