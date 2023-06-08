using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidUsernameException : ValidationException
    {
        public FieldIsNotAValidUsernameException(string fieldName = "")
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.FieldIsNotAValidUsername, fieldName))
        {
        }
    }
}