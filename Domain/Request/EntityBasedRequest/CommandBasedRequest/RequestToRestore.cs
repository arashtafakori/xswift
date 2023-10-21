using MediatR;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class RequestToRestore<TEntity> :
        BaseCommandRequest<TEntity>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        public async override Task ResolveAsync(IMediator mediator, TEntity entity)
        {
            await new InvariantState<TEntity>()
                .DefineAnInvariant(
                result: entity.Deleted == 0,
                issue: new NoEntityWasArchivedSoRestoringItIsNotPossible(typeof(TEntity).Name))
                .AssestAsync(mediator);

            entity.Restore();
        }
    }
}
