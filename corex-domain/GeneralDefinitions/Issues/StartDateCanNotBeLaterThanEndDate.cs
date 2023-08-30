using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class StartDateCanNotBeLaterThanEndDate : ValidationIssue
    {
        public StartDateCanNotBeLaterThanEndDate()
            : this(Resource.General_Entiy)
        { }
        public StartDateCanNotBeLaterThanEndDate(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_StartDateCanNotBeLaterThanEndDate, entityName);
        }
    }
}
