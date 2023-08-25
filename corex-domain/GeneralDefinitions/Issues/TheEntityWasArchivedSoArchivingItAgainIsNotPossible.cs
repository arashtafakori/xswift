using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWasArchivedSoArchivingItAgainIsNotPossible : InvariantIssue
    {
        public TheEntityWasArchivedSoArchivingItAgainIsNotPossible()
            : this(Resource.General_Entiy)
        { }
        public TheEntityWasArchivedSoArchivingItAgainIsNotPossible(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_TheEntityWasArchivedSoArchivingItAgainIsNotPossible, entityName);
        }
    }
}
