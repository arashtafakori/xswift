using XSwift.Properties;
using System.Globalization;

namespace XSwift.Domain
{
    public class FieldCanNotBeEmpty : ValidationIssue
    {
        public FieldCanNotBeEmpty(string fieldName = "", string description = "") :
            base(outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_FieldCanNotBeEmpty, fieldName))
        {
        }
    }
}