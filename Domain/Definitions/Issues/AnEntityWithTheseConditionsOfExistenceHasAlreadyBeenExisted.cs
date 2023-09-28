using XSwift.Properties;
using System.Globalization;

namespace XSwift.Domain
{
    public class AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted : LogicalIssue
    {
        public AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted(
            string entityName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Logical_Issue_AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted, entityName))
        {
        }
    }
}