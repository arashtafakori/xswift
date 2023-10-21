using MediatR;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class RequestToUpdate<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            entity.Update();
        }
    }
}
