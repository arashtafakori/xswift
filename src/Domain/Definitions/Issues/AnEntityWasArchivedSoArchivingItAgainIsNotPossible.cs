using System.Globalization;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents an invariant issue that occurs when attempting to archive an entity that has already been archived,
    /// and archiving it again is not possible.
    /// </summary>
    public class AnEntityWasArchivedSoArchivingItAgainIsNotPossible : InvariantIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnEntityWasArchivedSoArchivingItAgainIsNotPossible"/> class
        /// with the specified entity name and description.
        /// </summary>
        /// <param name="entityName">The name of the entity that has been archived.</param>
        /// <param name="description">A custom description for the issue (optional).</param>
        public AnEntityWasArchivedSoArchivingItAgainIsNotPossible(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                 "The {0} entity has been archived, so archiving it again is not possible."
                    , entityName))
        {
        }
    }
}
