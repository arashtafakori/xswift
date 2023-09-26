using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class NoEntityWasArchivedSoRestoringItIsNotPossible : InvariantIssue
    {
        public NoEntityWasArchivedSoRestoringItIsNotPossible(string entityName = "", string description = "")
        {
            Provide<NoEntityWasArchivedSoRestoringItIsNotPossible>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_Issue_NoEntityWasArchivedSoRestoringItIsNotPossible, entityName));
        }
    }
}
