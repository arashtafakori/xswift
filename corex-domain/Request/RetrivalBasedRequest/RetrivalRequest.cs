using CoreX.Base;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalRequest<TEntity> :
        Request where TEntity : BaseEntity
    {
        public bool TrackingMode { get; private set; }
        public bool EvenArchivedData { get; private set; }
        public bool ThrowExceptionIfEntityWasNotFound { get; set; } = false;

        public Expression<Func<TEntity, bool>> ExtraCondition { get; private set; }

        public RetrivalRequest(
            bool trackingMode = false,
            bool evenArchivedData = false)
        {
            TrackingMode = trackingMode;
            EvenArchivedData = evenArchivedData;
        }

        public virtual bool OnIncludingArchivedDataConfiguration()
        {
            return EvenArchivedData;
        }

        public virtual Expression<Func<TEntity, object>>? Include()
        {
            return null;
        }
        public virtual Expression<Func<TEntity, bool>>? Condition()
        {
            return null;
        }
    }
}
