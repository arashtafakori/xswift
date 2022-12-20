using CoreX.Base;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Structure
{
    public class EntityValidator
    {
        public void ValidateProperty(object source, object value, string memberName)
        {
            var context = new ValidationContext(source, null, null) { MemberName = memberName };
            Validator.ValidateProperty(value, context);
        }

        public EntityValidator ValidateProperty(object source, Expression<Func<AggregateRoot, object>> property)
        {
            var memberName = source.GetPropertyName(property);

            var context = new ValidationContext(source, null, null) { MemberName = memberName };
            Validator.ValidateProperty(source.GeValue(memberName), context);

            return this;
        }

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
