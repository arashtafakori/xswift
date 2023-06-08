using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsMoreThanMaximumLengthLimitException : ValidationException
    {
        public FieldLengthIsMoreThanMaximumLengthLimitException(int maxLength, string fieldName = "")
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.FieldLengthIsMoreThanMaximumLengthLimit, fieldName, maxLength))
        {
        }
    }
}