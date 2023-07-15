using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidEamilAddressIssue : Issue
    {
        public FieldIsNotAValidEamilAddressIssue(string fieldName = "")
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldIsNotAValidEmailAddress, fieldName);
        }
    }
}
