using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for validations.
    /// </summary>
    public abstract class Validation
    {
        /// <summary>
        /// Gets or sets the description of the validation.
        /// </summary>
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// Resolves the validation.
        /// </summary>
        /// <returns>True if the validation is successful, false otherwise.</returns>
        public virtual bool Resolve()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the issue associated with the validation.
        /// </summary>
        /// <returns>An instance implementing the <see cref="IIssue"/> interface representing the issue, or null if no issue is present.</returns>
        public virtual IIssue? GetIssue()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the description of the validation.
        /// </summary>
        /// <param name="value">The value to set as the description.</param>
        /// <returns>The current instance of the validation for fluent chaining.</returns>
        public Validation WithDescription(string value)
        {
            Description = value;
            return this;
        }
    }
}
