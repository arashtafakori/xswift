using MediatR;

namespace CoreX.Domain
{
    public abstract class BaseCommandRequest<TEntity> :
        ModelBasedRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
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
            throw new NotImplementedException();
        }
        public virtual void Resolve(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public async virtual Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
