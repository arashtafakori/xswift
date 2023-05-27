using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNullException : ValidationException
    {
        public FieldIsNullException(string filedName = "")
            : base(string.Format(CultureInfo.CurrentCulture,
                Resource.FieldCanNotBeEmpty_ValidationError, filedName))
        {
        }
    }
}