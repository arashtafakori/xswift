using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a invariant issue in the domain model.
    /// </summary>
    public class InvariantIssue : IIssue
    {
        /// <summary>
        /// Gets or sets the name of the invariant issue.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the invariant issue.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantIssue"/> class with optional descriptions.
        /// </summary>
        /// <param name="outerDescription">The outer description of the invariant issue.</param>
        /// <param name="innerDescription">The inner description of the invariant issue.</param>
        public InvariantIssue(
            string outerDescription,
            string innerDescription)
        {
            // Set the name of the invariant issue to the full type name.
            Name = GetType().FullName!;

            // Determine the description based on the provided parameters.
            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = "An invariant error has happened.";
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
