using System.Runtime.Serialization;

namespace XSwift.Base
{
    /// <summary>
    /// Represents an interface for defining issues.
    /// </summary>
    public interface IIssue
    {
        /// <summary>
        /// Gets or sets the name of the issue.
        /// </summary>
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the issue.
        /// </summary>
        [DataMember(Order = 2)]
        public string Description { get; set; }
    }
}
