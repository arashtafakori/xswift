using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class Entity<TEntity> : BaseEntity where TEntity : BaseEntity
    {
        private static readonly PropertyAttributes<TEntity> _attributes = new();
        //public InvariantContext<TEntity> Invariant { get; private set; }
        public static PropertyAttributes<TEntity> Property(Expression<Func<TEntity, string>> expression)
        {
            return _attributes.Of(expression);
        }

        //public Entity()
        //{
        //    Invariant = new();
        //}
    }
}
