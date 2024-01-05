using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a validation issue in the domain model.
    /// </summary>
    public class ValidationIssue : IIssue
    {
        /// <summary>
        /// Gets or sets the name of the validation issue.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the validation issue.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationIssue"/> class with optional descriptions.
        /// </summary>
        /// <param name="outerDescription">The outer description of the validation issue.</param>
        /// <param name="innerDescription">The inner description of the validation issue.</param>
        public ValidationIssue(
            string outerDescription = "",
            string innerDescription = "")
        {
            // Set the name of the validation issue to the full type name.
            Name = GetType().FullName!;

            // Determine the description based on the provided parameters.
            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = "A validation error has happened.";
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
