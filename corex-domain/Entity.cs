using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class Entity<TEntity> : BaseEntity
    {
        private static readonly PropertyAttributes<TEntity> _attributes = new();

        public static PropertyAttributes<TEntity> Property(Expression<Func<TEntity, string>> expression)
        {
            return _attributes.Of(expression);
        }
    }
}
