using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Artaware.Infrastructure.CoreX
{
    internal class EntityValidator
    {
        internal void Validate(object source)
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
