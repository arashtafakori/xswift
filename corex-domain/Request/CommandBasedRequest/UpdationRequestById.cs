using MediatR;

namespace CoreX.Domain
{
    public abstract class UpdationRequestById<TRequest, TEntity, IdType> :
        CommandRequestById<TEntity, IdType>, IRequestResolver<TRequest, TEntity>
        where TRequest : Request where TEntity : EntityById<TEntity, IdType>
    {
        public UpdationRequestById(IdType id) : base(id)
        {
        }

        public virtual TEntity ResolveAndGetEntity()
        {
            throw new NotImplementedException();
        }
        public virtual List<TEntity> ResolveAndGetEntities()
        {
            throw new NotImplementedException();
        }
        public virtual Task<TEntity> ResolveAndGetEntityAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public virtual Task<List<TEntity>> ResolveAndGetEntitiesAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public virtual void Resolve(TEntity entity)
        {
            entity.Updation();
        }
        public virtual void Resolve(List<TEntity> entities)
        {
            entities.ForEach(e => { e.Updation(); });
        }
    }
}
