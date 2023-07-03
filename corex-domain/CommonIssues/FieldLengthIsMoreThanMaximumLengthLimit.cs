using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsMoreThanMaximumLengthLimit : Issue
    {
        public FieldLengthIsMoreThanMaximumLengthLimit(int maxLength, string fieldName = "")
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldLengthIsMoreThanMaximumLengthLimit, fieldName, maxLength);
        }
    }
}
