using MediatR;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class BaseCommandRequest<TEntity> :
        EntityBasedRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public virtual Expression<Func<TEntity, bool>>? Identification()
        {
            return null;
        }

        public virtual Task<TEntity> ResolveAndGetEntityAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }
        public async virtual Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            throw new NotImplementedException();
        }
        public async virtual Task NextAsync(IMediator mediator, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
