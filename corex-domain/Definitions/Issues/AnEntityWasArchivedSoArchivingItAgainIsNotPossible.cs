using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class AnEntityWasArchivedSoArchivingItAgainIsNotPossible : InvariantIssue
    {
        public AnEntityWasArchivedSoArchivingItAgainIsNotPossible(
            string entityName = "", string description = "")
        {
            Provide<AnEntityWasArchivedSoArchivingItAgainIsNotPossible>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_Issue_AnEntityWasArchivedSoArchivingItAgainIsNotPossible, entityName));
        }
    }
}
