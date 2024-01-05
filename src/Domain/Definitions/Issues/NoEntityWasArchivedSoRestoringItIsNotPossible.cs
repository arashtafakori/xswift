using System.Globalization;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents an invariant issue that occurs when attempting to restore an entity that has not been archived,
    /// and restoring it is not possible.
    public class NoEntityWasArchivedSoRestoringItIsNotPossible : InvariantIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoEntityWasArchivedSoRestoringItIsNotPossible"/> class
        /// with the specified entity name and description.
        /// </summary>
        /// <param name="entityName">The name of the entity that has not been archived.</param>
        /// <param name="description">A custom description for the invariant issue (optional).</param>
        public NoEntityWasArchivedSoRestoringItIsNotPossible(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "No {0} entity has not been archived, so restoring it is not possible.",
                entityName))
        {
        }
    }
}
