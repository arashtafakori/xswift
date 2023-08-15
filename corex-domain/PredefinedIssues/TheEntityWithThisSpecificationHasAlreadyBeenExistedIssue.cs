using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue : InvariantIssue
    {
        public TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue()
            : this(Resource.General_Entiy)
        { }
        public TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_TheEntityWithThisSpecificationHasAlreadyBeenExisted, entityName);
        }
    }
}