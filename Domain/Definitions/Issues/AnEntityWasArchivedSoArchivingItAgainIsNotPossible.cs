using XSwift.Properties;
using System.Globalization;

namespace XSwift.Domain
{
    public class AnEntityWasArchivedSoArchivingItAgainIsNotPossible : InvariantIssue
    {
        public AnEntityWasArchivedSoArchivingItAgainIsNotPossible(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_Issue_AnEntityWasArchivedSoArchivingItAgainIsNotPossible, entityName))
        {
        }
    }
}
