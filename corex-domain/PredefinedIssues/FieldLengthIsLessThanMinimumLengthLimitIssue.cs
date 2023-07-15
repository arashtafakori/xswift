using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsLessThanMinimumLengthLimitIssue : Issue
    {
        public FieldLengthIsLessThanMinimumLengthLimitIssue(int minLength, string fieldName = "")
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldLengthIsLessThanMinimumLengthLimit, fieldName, minLength);
        }
    }
}
