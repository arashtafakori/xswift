using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class TheEntityWithThisSpecificationHasAlreadyBeenExisted : Issue
    {
        public TheEntityWithThisSpecificationHasAlreadyBeenExisted()
            : this(Resource.Entiy)
        { }
        public TheEntityWithThisSpecificationHasAlreadyBeenExisted(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.TheEntityWithThisSpecificationHasAlreadyBeenExisted, entityName);
        }
    }
}