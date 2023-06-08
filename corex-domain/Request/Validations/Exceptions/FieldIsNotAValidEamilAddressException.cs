using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidEamilAddressException : ValidationException
    {
        public FieldIsNotAValidEamilAddressException(string fieldName = "")
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.FieldIsNotAValidEmailAddress, fieldName))
        {
        }
    }
}