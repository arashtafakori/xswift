using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWasNotArchivedSoRestoringItIsNotPossibleIssue : InvariantIssue
    {
        public TheEntityWasNotArchivedSoRestoringItIsNotPossibleIssue()
            : this(Resource.General_Entiy)
        { }
        public TheEntityWasNotArchivedSoRestoringItIsNotPossibleIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_TheEntityWasNotArchivedSoRestoringItIsNotPossible, entityName);
        }
    }
}
