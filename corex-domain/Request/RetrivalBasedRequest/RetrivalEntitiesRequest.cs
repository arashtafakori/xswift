using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalEntitiesRequest<TEntity> :
        RetrivalRequest<TEntity> where TEntity : BaseEntity
    {
        public RetrivalEntitiesRequest(bool trackingMode = false)
            : base(trackingMode: trackingMode) { }

        public virtual Expression<Func<TEntity, object>>? OrderBy()
        {
            return null;
        }
        public virtual Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return null;
        }
    }
}
