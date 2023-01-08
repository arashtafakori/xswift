using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Artaware.Infrastructure.CoreX
{
    public static class AttributeHelper
    {

        public static Int32 GetMaxLength<T>(Expression<Func<T, string>> property)
        {
            return GetPropertyAttributeValue<T, string, MaxLengthAttribute, Int32>(property, attr => attr.Length);
        }
        public static Int32 GetMinLength<T>(Expression<Func<T, string>> property)
        {
            return GetPropertyAttributeValue<T, string, MinLengthAttribute, Int32>(property, attr => attr.Length);
        }
        public static Int32 GetStringLength<T>(Expression<Func<T, string>> property)
        {
            return GetPropertyAttributeValue<T, string, StringLengthAttribute, Int32>(property, attr => attr.MinimumLength);
        }
        public static bool IsRequired<T>(Expression<Func<T, object>> property)
        {
            return GetPropertyAttributeValue<T, object, RequiredAttribute, bool>(property, attr => attr.AllowEmptyStrings);
        }

        //Optional Extension method
        public static Int32 GetMaxLength<T>(this T instance, Expression<Func<T, string>> property)
        {
            return GetMaxLength<T>(property);
        }
        public static Int32 GetMinLength<T>(this T instance, Expression<Func<T, string>> property)
        {
            return GetMinLength<T>(property);
        }
        public static Int32 GetStringLength<T>(this T instance, Expression<Func<T, string>> property)
        {
            return GetStringLength<T>(property);
        }
        public static bool IsRequired<T>(this T instance, Expression<Func<T, object>> property)
        {
            return IsRequired<T>(property);
        }

        //Required generic method to get any property attribute from any class
        public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(Expression<Func<T, TOut>> property, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            var expression = (MemberExpression)property.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (attr == null)
            {
                throw new MissingMemberException(typeof(T).Name + "." + propertyInfo.Name, typeof(TAttribute).Name);
            }

            return valueSelector(attr);
        }
    }
}
