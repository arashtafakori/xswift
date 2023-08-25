using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidEamilAddress : ValidationIssue
    {
        public FieldIsNotAValidEamilAddress(
            string fieldName = "", string errorMessage = "")
            : base(errorMessage)
        {
            Name = GetType().FullName!;

            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_FieldIsNotAValidEmailAddress, fieldName);
        }
    }
}
