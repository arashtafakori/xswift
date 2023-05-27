using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace CoreX.Domain
{
    public class PropertyAttributes<T>  
    {
        private Expression<Func<T, string>>? _property;
        public PropertyAttributes<T> Of(Expression<Func<T, string>> property)
        {
            _property = property;
            return this;
        }

        public Int32 MaxLength 
        {
            get
            {
                return GetPropertyAttributeValue<string, MaxLengthAttribute, Int32>(attr => attr.Length);
            }
        }
        public Int32 MinLength
        {
            get
            {
                return GetPropertyAttributeValue<string, MinLengthAttribute, Int32>(attr => attr.Length);
            }
        }
        public Int32 StringLength 
        {
            get
            {
                return GetPropertyAttributeValue<string, StringLengthAttribute, Int32>(attr => attr.MinimumLength);
            }
        }
        public bool IsEmptyStringsAllowed
        {
            get
            {
                return GetPropertyAttributeValue<object, RequiredAttribute, bool>(attr => attr.AllowEmptyStrings);
            }
        }
        public bool IsRequired
        {
            get
            {
                return HasPropertyAttributeValue<RequiredAttribute>();
            }
        }

        private TValue GetPropertyAttributeValue<TOut, TAttribute, TValue>
            (Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var expression = (MemberExpression)_property.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null)
            {
                throw new MissingMemberException(typeof(T).Name + "." + propertyInfo.Name, typeof(TAttribute).Name);
            }

            return valueSelector(attr);
        }

        private bool HasPropertyAttributeValue<TAttribute>() where TAttribute : Attribute
        {
            var expression = (MemberExpression)_property.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null)
                return false;

            return true;
        }
    }
}
