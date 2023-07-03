using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;
namespace CoreX.Domain
{
    public class FieldCanNotBeEmpty : Issue
    {
        public FieldCanNotBeEmpty()
            : this(Resource.Entiy)
        { }
        public FieldCanNotBeEmpty(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldCanNotBeEmpty, entityName);
        }
    }
}