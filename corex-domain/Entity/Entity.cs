using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class Entity<TEntity, IdType> :
        BaseEntity
    {
        [Required]
        public IdType Id { get; private set; }
        public virtual Expression<Func<TEntity, bool>>? UniqueSpecification()
        {
            return null;
        }
    }
}
