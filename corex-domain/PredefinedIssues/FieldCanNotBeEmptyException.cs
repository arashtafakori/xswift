using CoreX.Base;
using CoreX.Domain.Properties;
using System.Globalization;
namespace CoreX.Domain
{
    public class FieldCanNotBeEmptyIssue : Issue
    {
        public FieldCanNotBeEmptyIssue()
            : this(Resource.Entiy)
        { }
        public FieldCanNotBeEmptyIssue(string entityName)
        {
            Name = GetType().FullName!;
            Description = string.Format(CultureInfo.CurrentCulture,
                Resource.FieldCanNotBeEmpty, entityName);
        }
    }
}