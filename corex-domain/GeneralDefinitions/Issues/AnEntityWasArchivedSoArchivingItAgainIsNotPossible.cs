using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class AnEntityWasArchivedSoArchivingItAgainIsNotPossible : InvariantIssue
    {
        public AnEntityWasArchivedSoArchivingItAgainIsNotPossible()
            : this(Resource.General_Entiy)
        { }
        public AnEntityWasArchivedSoArchivingItAgainIsNotPossible(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_AnEntityWasArchivedSoArchivingItAgainIsNotPossible, entityName);
        }
    }
}
