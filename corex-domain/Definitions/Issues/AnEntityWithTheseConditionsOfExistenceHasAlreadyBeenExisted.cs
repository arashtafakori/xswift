using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted : LogicalIssue
    {
        public AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted(string entityName = "", string description = "")
        {
            Provide<AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Logical_Issue_AnEntityWithTheseConditionsOfExistenceHasAlreadyBeenExisted, entityName));
        }
    }
}