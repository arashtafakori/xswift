using XSwift.Properties;
using System.Globalization;

namespace XSwift.Domain
{
    public class FieldLengthIsLessThanMinimumLengthLimit : ValidationIssue
    {
        public FieldLengthIsLessThanMinimumLengthLimit(
            int minLength, string fieldName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_FieldLengthIsLessThanMinimumLengthLimit, fieldName, minLength))
        {
        }
    }
}
