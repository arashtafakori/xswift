using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class StartDateCanNotBeLaterThanEndDate : ValidationIssue
    {
        public StartDateCanNotBeLaterThanEndDate(string entityName = "", string description = "")
        {
            Provide<StartDateCanNotBeLaterThanEndDate>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_StartDateCanNotBeLaterThanEndDate, entityName));
        }
    }
}
