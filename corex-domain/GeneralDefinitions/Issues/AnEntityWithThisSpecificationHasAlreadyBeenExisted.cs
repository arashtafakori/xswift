using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class AnEntityWithThisSpecificationHasAlreadyBeenExisted : InvariantIssue
    {
        public AnEntityWithThisSpecificationHasAlreadyBeenExisted()
            : this(Resource.General_Entiy)
        { }
        public AnEntityWithThisSpecificationHasAlreadyBeenExisted(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Invariant_AnEntityWithThisSpecificationHasAlreadyBeenExisted, entityName);
        }
    }
}