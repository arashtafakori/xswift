using MediatR;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public interface IRequestResolver<TRequest, TEntity> 
        where TRequest : Request where TEntity : BaseEntity
    {
        public TEntity ResolveAndGetEntity();
        public List<TEntity> ResolveAndGetEntities();
        public Task<TEntity> ResolveAndGetEntityAsync(IMediator mediator);
        public Task<List<TEntity>> ResolveAndGetEntitiesAsync(IMediator mediator);
        public void Resolve(TEntity entity);
        public void Resolve(List<TEntity> entities);
        public Task ResolveAsync(IMediator mediator, TEntity entity);
        public Task ResolveAsync(IMediator mediator, List<TEntity> entities);

        public virtual Expression<Func<TEntity, bool>>? Condition()
        {
            return null;
        }
    }
}
