using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWasArchivedSoArchivingItAgainIsNotPossibleIssue : InvariantIssue
    {
        public TheEntityWasArchivedSoArchivingItAgainIsNotPossibleIssue()
            : this(Resource.General_Entiy)
        { }
        public TheEntityWasArchivedSoArchivingItAgainIsNotPossibleIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_TheEntityWasArchivedSoArchivingItAgainIsNotPossible, entityName);
        }
    }
}
