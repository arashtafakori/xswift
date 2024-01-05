using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a logical issue in the domain model.
    /// </summary>
    public class LogicalIssue : IIssue
    {
        /// <summary>
        /// Gets or sets the name of the logical issue.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the logical issue.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalIssue"/> class with the specified descriptions.
        /// </summary>
        /// <param name="outerDescription">The outer description of the logical issue.</param>
        /// <param name="innerDescription">The inner description of the logical issue.</param>
        public LogicalIssue(
            string outerDescription,
            string innerDescription)
        {
            // Set the name of the logical issue to the full type name.
            Name = GetType().FullName!;

            // Determine the description based on the provided parameters.
            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = "A logical error has happened.";
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
