using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsLessThanMinimumLengthLimitException : ValidationException
    {
        public FieldLengthIsLessThanMinimumLengthLimitException(int minLength, string fieldName = "")
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.FieldLengthIsLessThanMinimumLengthLimit, fieldName, minLength))
        {
        }
    }
}