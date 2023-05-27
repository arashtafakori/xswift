using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public class AggregateRoot<TEntity> : Entity<TEntity>
    {
        public AggregateRoot()
        {
        }
    }
}
