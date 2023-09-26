using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreX.Domain
{
    public abstract class Entity<TEntity, IdType> :
        BaseEntity<TEntity>
    {
        [Required]
        [Column(Order = 0)]
        public IdType Id { get; private set; }
        public void SetId(IdType value)
        {
            Id = value;
        }
    }
}
