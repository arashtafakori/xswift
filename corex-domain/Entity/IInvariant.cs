using System.Linq.Expressions;

namespace CoreX.Domain
{
    public interface IInvariant<TEntity> where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>>? Condition { get; }

        void ThrowException();
    }
}
