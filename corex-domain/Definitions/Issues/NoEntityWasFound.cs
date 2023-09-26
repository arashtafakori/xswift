using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class NoEntityWasFound : LogicalIssue
    {
        public NoEntityWasFound(string entityName = "", string description = "")
        {
            Provide<NoEntityWasFound>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_Issue_NoEntityWasFound, entityName));
        }
    }
}