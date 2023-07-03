using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;

namespace CoreX.Domain
{
    public class FieldIsNull : Issue
    {
        public FieldIsNull(string fieldName = "")
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldCanNotBeEmpty, fieldName);
        }
    }
}
