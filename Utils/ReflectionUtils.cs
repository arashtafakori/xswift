using System.Linq.Expressions;
using System.Reflection;

namespace Artaware.Infrastructure.CoreX
{
    public static class ReflectionUtils
    {
        public static T GetAttributeFrom<T>(object source, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = source.GetType().GetProperty(propertyName);
            return (T)property!.GetCustomAttributes(attrType, false).First();
        }
        public static List<Attribute> GetAttributes<TEntity>(Expression<Func<TEntity, object>> property)
            where TEntity : class
        {
            var myAttrs = new List<Attribute>();

            var member = GetMember(property);

            object[] attributes = member.GetCustomAttributes(true);
            foreach (Attribute attr in attributes)
            {
                myAttrs.Add(attr);
            }

            return myAttrs;
        }
        public static MemberInfo GetMember<TEntity>(Expression<Func<TEntity, object>> property) where TEntity : class
        {
            MemberExpression body = property.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)property.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member;
        }
        public static bool IsIplementedInterfaceOf(Type source, Type interfaceType)
        {
            return (
                from iType in source.GetInterfaces()
                where iType == interfaceType
                select iType).Any();
        }
    }
}
