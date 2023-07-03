using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class Entity<TEntity> : 
        BaseEntity where TEntity : BaseEntity
    {
        public virtual Expression<Func<TEntity, bool>>? UniqueSpecification()
        {
            return null;
        }
    }
}
