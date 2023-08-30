using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class NoEntityWasArchivedSoRestoringItIsNotPossible : InvariantIssue
    {
        public NoEntityWasArchivedSoRestoringItIsNotPossible()
            : this(Resource.General_Entiy)
        { }
        public NoEntityWasArchivedSoRestoringItIsNotPossible(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_NoEntityWasArchivedSoRestoringItIsNotPossible, entityName);
        }
    }
}
