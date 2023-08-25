using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWasNotArchivedSoRestoringItIsNotPossible : InvariantIssue
    {
        public TheEntityWasNotArchivedSoRestoringItIsNotPossible()
            : this(Resource.General_Entiy)
        { }
        public TheEntityWasNotArchivedSoRestoringItIsNotPossible(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_TheEntityWasNotArchivedSoRestoringItIsNotPossible, entityName);
        }
    }
}
