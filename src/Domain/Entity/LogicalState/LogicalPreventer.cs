using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for logical preventers in the domain model.
    /// </summary>
    public abstract class LogicalPreventer
    {
        /// <summary>
        /// Gets or sets the description of the logical preventer.
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Asynchronously resolves the logical preventer.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a boolean indicating resolution success.</returns>
        public virtual Task<bool> ResolveAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the issue associated with the logical preventer.
        /// </summary>
        /// <returns>An instance implementing the <see cref="IIssue"/> interface representing the issue, or null if no issue is present.</returns>
        public virtual IIssue? GetIssue()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the description of the logical preventer.
        /// </summary>
        /// <param name="value">The value to set as the description.</param>
        /// <returns>The current instance of the logical preventer for fluent chaining.</returns>
        public LogicalPreventer WithDescription(string value)
        {
            Description = value;
            return this;
        }
    }
}
