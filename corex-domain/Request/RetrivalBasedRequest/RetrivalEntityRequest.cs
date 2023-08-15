using MediatR;

namespace CoreX.Domain
{
    public abstract class RetrivalEntityRequest<TEntity> :
        RetrivalRequest<TEntity> where TEntity : BaseEntity
    {
        public RetrivalEntityRequest(
            bool trackingMode = false,
            bool evenArchivedData = false)
            : base(trackingMode : trackingMode,
                  evenArchivedData: evenArchivedData) { }

        public virtual void Resolve(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(TEntity entity, IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
