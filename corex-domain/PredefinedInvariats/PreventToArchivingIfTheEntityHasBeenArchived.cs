﻿using CoreX.Base;
using CoreX.Domain;
using MediatR;

namespace CoreX.Domain
{
    public class PreventToArchivingIfTheEntityHasBeenArchived<TEntity> :
        IInvariant
        where TEntity : BaseEntity
    {
        private TEntity _entity { get; set; }
        public PreventToArchivingIfTheEntityHasBeenArchived
            (TEntity entity)
        {
            _entity = entity;
        }

        public Task<bool> CheckAsync(IMediator mediator)
        {
            if(_entity.Deleted != 0)
                return Task.FromResult(true);

            return Task.FromResult(false);
        }

        public IIssue? GetIssue()
        {
            return new TheEntityWasArchivedSoArchivingItAgainIsNotPossibleIssue(typeof(TEntity).Name);
        }
    }
}
