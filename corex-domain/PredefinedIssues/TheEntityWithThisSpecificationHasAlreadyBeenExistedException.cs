using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue : Issue
    {
        public TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue()
            : this(Resource.Entiy)
        { }
        public TheEntityWithThisSpecificationHasAlreadyBeenExistedIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.TheEntityWithThisSpecificationHasAlreadyBeenExisted, entityName);
        }
    }
}