using XSwift.Properties;
using System.Globalization;

namespace XSwift.Domain
{
    public class AnEntityWithTheseUniquenessConditionsHasAlreadyBeenExisted : LogicalIssue
    {
        public AnEntityWithTheseUniquenessConditionsHasAlreadyBeenExisted(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Logical_Issue_AnEntityWithTheseUniquenessConditionsHasAlreadyBeenExisted, entityName))
        {
        }
    }
}