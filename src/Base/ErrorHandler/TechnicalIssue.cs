namespace XSwift.Base
{
    /// <summary>
    /// Represents a technical issue associated with errors in the application.
    /// </summary>
    public class TechnicalIssue : IIssue
    {
        /// <summary>
        /// Gets or sets the name of the technical issue.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the technical issue.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
