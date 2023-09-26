using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldCanNotBeEmpty : ValidationIssue
    {
        public FieldCanNotBeEmpty(string fieldName = "", string description = "")
        {
            Provide<FieldCanNotBeEmpty>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_FieldCanNotBeEmpty, fieldName));
        }
    }
}