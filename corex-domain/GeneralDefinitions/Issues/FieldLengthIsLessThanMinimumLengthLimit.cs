using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsLessThanMinimumLengthLimit : ValidationIssue
    {
        public FieldLengthIsLessThanMinimumLengthLimit(
            int minLength, string fieldName = "", string errorMessage = "")
            : base(errorMessage)
        {
            Name = GetType().FullName!;

            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_FieldLengthIsLessThanMinimumLengthLimit, fieldName, minLength);
        }
    }
}
