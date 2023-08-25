using CoreX.Base;
using CoreX.Domain;
using MediatR;

namespace CoreX.Domain
{
    public class PreventToRestoringIfTheEntityHasNotBeenArchived<TEntity> :
        IInvariant
        where TEntity : BaseEntity
    {
        private TEntity _entity { get; set; }
        public PreventToRestoringIfTheEntityHasNotBeenArchived
            (TEntity entity)
        {
            _entity = entity;
        }

        public Task<bool> CheckAsync(IMediator mediator)
        {
            if(_entity.Deleted == 0)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        public IIssue? GetIssue()
        {
            return new TheEntityWasNotArchivedSoRestoringItIsNotPossible(typeof(TEntity).Name);
        }
    }
}
