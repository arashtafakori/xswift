using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldLengthIsLessThanMinimumLengthLimit : Issue
    {
        public FieldLengthIsLessThanMinimumLengthLimit(int minLength, string fieldName = "")
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldLengthIsLessThanMinimumLengthLimit, fieldName, minLength);
        }
    }
}
