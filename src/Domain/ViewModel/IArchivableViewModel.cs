namespace XSwift.Domain
{
    /// <summary>
    /// Represents a view model that supports archiving functionality.
    /// </summary>
    public interface IArchivableViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the item is archived.
        /// </summary>
        public bool IsArchived { get; set; }
    }
}
