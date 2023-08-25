using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldCanNotBeEmpty : ValidationIssue
    {
        public FieldCanNotBeEmpty(
            string fieldName = "", string errorMessage = "")
            : base(errorMessage)
        {
            Name = GetType().FullName!;

            Description += string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_FieldCanNotBeEmpty, fieldName);
        }
    }
}