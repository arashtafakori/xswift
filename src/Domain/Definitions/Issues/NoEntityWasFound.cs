using System.Globalization;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents an invariant issue that occurs when no entity with the specified criteria is found.
    /// </summary>
    public class NoEntityWasFound : LogicalIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEntityWasFound"/> class
        /// with the specified entity name and description.
        /// </summary>
        /// <param name="entityName">The name of the entity that was not found.</param>
        /// <param name="description">A custom description for the invariant issue (optional).</param>
        public NoEntityWasFound(string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "No {0} entity was found.", entityName))
        {
        }
    }
}