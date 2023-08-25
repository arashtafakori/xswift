using MediatR;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RestorationRequestById<TRequest, TEntity, IdType> :
        CommandRequestById<TEntity, IdType>, IRequestResolver<TRequest, TEntity>
        where TRequest : Request where TEntity : Entity<TEntity, IdType>
    {
        public RestorationRequestById(IdType id) : base(id)
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
        public virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public virtual void Resolve(TEntity entity)
        {
            entity.Restore();
        }
        public virtual void Resolve(List<TEntity> entities)
        {
            entities.ForEach(e => { e.Restore(); });
        }
        public async virtual Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            await new InvariantState
            {
                new PreventToRestoringIfTheEntityHasNotBeenArchived<TEntity>(entity!)
            }.CheckAsync(mediator);

            entity.Restore();
        }
        public async virtual Task ResolveAsync(IMediator mediator, List<TEntity> entities)
        {
            entities.ForEach(async entity => {
                await new InvariantState
                {
                    new PreventToRestoringIfTheEntityHasNotBeenArchived<TEntity>(entity!)
                }.CheckAsync(mediator);
                entity.Restore();
            });
        }
    }
}
