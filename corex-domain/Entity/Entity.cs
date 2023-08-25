using MassTransit.Transports;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class Entity<TEntity, IdType> :
        BaseEntity
    {
        [Required]
        [Column(Order = 0)]
        public IdType Id { get; private set; }
        public virtual Expression<Func<TEntity, bool>>? UniqueSpecification()
        {
            return null;
        }
    }
}
