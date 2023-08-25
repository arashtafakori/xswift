using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWithThisSpecificationHasAlreadyBeenExisted : InvariantIssue
    {
        public TheEntityWithThisSpecificationHasAlreadyBeenExisted()
            : this(Resource.General_Entiy)
        { }
        public TheEntityWithThisSpecificationHasAlreadyBeenExisted(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_TheEntityWithThisSpecificationHasAlreadyBeenExisted, entityName);
        }
    }
}