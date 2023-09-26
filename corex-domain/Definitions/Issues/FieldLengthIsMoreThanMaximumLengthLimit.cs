using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsMoreThanMaximumLengthLimit : ValidationIssue
    {
        public FieldLengthIsMoreThanMaximumLengthLimit(int maxLength, string fieldName = "", string description = "")
        {
            Provide<FieldLengthIsMoreThanMaximumLengthLimit>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_FieldLengthIsMoreThanMaximumLengthLimit, fieldName, maxLength));
        }
    }
}
