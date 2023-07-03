using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class CommandRequest<TEntity> : Request
    {
        public virtual Expression<Func<TEntity, bool>>? Condition()
        {
            return null;
        }
    }
}
