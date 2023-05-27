using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidUsernameException : ValidationException
    {
        public FieldIsNotAValidUsernameException(int minLength, int maxLength, string filedName = "")
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.FieldIsNotAValidUsername_ValidationError, filedName, minLength, maxLength))
        {
        }
    }
}