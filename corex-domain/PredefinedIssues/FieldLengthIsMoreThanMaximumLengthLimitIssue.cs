using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsMoreThanMaximumLengthLimitIssue : ValidationIssue
    {
        public FieldLengthIsMoreThanMaximumLengthLimitIssue(
            int maxLength, string fieldName = "", string errorMessage = "") 
            : base(errorMessage)
        {
            Name = GetType().FullName!;

            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_FieldLengthIsMoreThanMaximumLengthLimit, fieldName, maxLength);
        }
    }
}
