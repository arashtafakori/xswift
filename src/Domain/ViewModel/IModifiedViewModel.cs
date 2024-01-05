namespace XSwift.Domain
{
    /// <summary>
    /// Represents a view model that tracks the last modification date.
    /// </summary>
    public interface IModifiedViewModel
    {
        /// <summary>
        /// Gets or sets the date and time when the item was last modified.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
