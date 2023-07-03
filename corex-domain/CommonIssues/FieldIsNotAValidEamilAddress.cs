using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNotAValidEamilAddress : Issue
    {
        public FieldIsNotAValidEamilAddress(string fieldName = "")
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldIsNotAValidEmailAddress, fieldName);
        }
    }
}
