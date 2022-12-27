using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Artaco.Infrastructure.CoreX
{
    internal class EntityValidator
    {
        public void Validate(object source)
        {
            foreach (PropertyInfo propertyInfo in source.GetType().GetProperties())
            {
                var memberName = propertyInfo.Name;
                var context = new ValidationContext(source, null, null) { MemberName = memberName };
                Validator.ValidateProperty(source.GeValue(memberName), context);
            }
        }
    }
}
