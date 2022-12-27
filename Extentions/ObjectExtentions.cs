using System.Linq.Expressions;

namespace Artaco.Infrastructure.CoreX
{
    public static class ObjectExtentions
    {
        public static object GeValue(this object source, string memberName)
        {
            return source.GetType().GetProperty(memberName)!.GetValue(source, null)!;
        }
        public static string GetPropertyName<TEntity>(this object source, Expression<Func<TEntity, object>> property) where TEntity : class
        {
            return ReflectionUtils.GetMember(property).Name;
        }
    }
}
