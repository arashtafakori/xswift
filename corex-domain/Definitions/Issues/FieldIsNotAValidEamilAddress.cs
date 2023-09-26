using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidEamilAddress : ValidationIssue
    {
        public FieldIsNotAValidEamilAddress(string fieldName = "", string description = "")
        {
            Provide<FieldIsNotAValidEamilAddress>(
                outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_FieldIsNotAValidEmailAddress, fieldName));
        }
    }
}
