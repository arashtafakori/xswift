using MediatR;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalEntitiesRequest<TEntity> :
        RetrivalRequest<TEntity> where TEntity : BaseEntity
    {
        public RetrivalEntitiesRequest(
            bool trackingMode = false,
            bool evenArchivedData = false)
            : base(trackingMode: trackingMode,
                  evenArchivedData: evenArchivedData) { }

        public virtual Expression<Func<TEntity, object>>? OrderBy()
        {
            return null;
        }
        public virtual Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return null;
        }

        public virtual void Resolve(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(List<TEntity> entities, IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
