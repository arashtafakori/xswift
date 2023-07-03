using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalRequest<TEntity> :
        Request where TEntity : BaseEntity
    {
        public bool TrackingMode { get; private set; }
        public bool ThrowExceptionIfEntityWasNotFound { get; set; } = false;

        public RetrivalRequest(bool trackingMode = false)
        {
            TrackingMode = trackingMode;
        }

        public virtual bool HasIncludedArchivedEntities()
        {
            return false;
        }
        public virtual Expression<Func<TEntity, bool>>? Condition()
        {
            return null;
        }
        public virtual Expression<Func<TEntity, object>>? Include()
        {
            return null;
        }
    }
}
