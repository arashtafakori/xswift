using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace CoreX.Structure
{
    public interface IDatabase
    {
        public bool Tracking { get; }
        public void AsNoTraking();
        public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext;

        #region create Update

        public Task Create<TEntity>
            (TEntity entity, Expression<Func<TEntity, bool>>? noCreateWhere = null)
            where TEntity : Model;

        public Task Update<TEntity>
    (TEntity entity, Expression<Func<TEntity, bool>>? noUpdateWhere = null)
    where TEntity : Model;

        #endregion

        #region delete
        public Task Delete<TEntity>
    (TEntity entity, CascadeSoftDeleteConfiguration<ICascadeSoftDelete> configCascadeDelete,
    Expression<Func<TEntity, bool>>? noDeleteWhere = null) where TEntity : AggregateRoot;

        public Task UndoDeleting<TEntity>
            (TEntity entity, CascadeSoftDeleteConfiguration<ICascadeSoftDelete> configCascadeDelete,
            Expression<Func<TEntity, bool>>? noUndoDeletingWhere = null) where TEntity : AggregateRoot;

        public Task<bool> IsValidToHardDelete<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ICascadeSoftDelete> configCascadeDelete)
            where TEntity : AggregateRoot;

        public Task HardDelete<TEntity>
            (TEntity entity, Expression<Func<TEntity, bool>>? noDeleteWhere = null) where TEntity : Model;
        public Task HardDelete<TEntity>
            (Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>>? noDeleteWhere = null)
            where TEntity : Model;

        //public async Task Delete<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task UndoDeleting<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task IsValidToHardDelete<TEntity>(Expression<Func<TEntity, bool>> where

        //public async Task DeleteViaKeys<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task UndoDeletingViaKeys<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task IsValidToHardDeleteViaKeys<TEntity>(Expression<Func<TEntity, bool>> where
        #endregion

        #region retrieve
        public Task<TEntity> Single<TEntity>(
          Expression<Func<TEntity, bool>> where,
          Expression<Func<TEntity, object>>? include = null,
          bool? tracking = null,
          bool evenDeleted = false,
          bool throwExceptionIfTheEntityNouFound = true)
          where TEntity : Model;

        public Task<TEntity> Find<TEntity>(
            object[] KeyValues,
            bool throwExceptionIfTheEntityNouFound = true
            ) where TEntity : Model;

        public Task<TEntity> Find<TEntity>(
            object KeyValue,
            bool throwExceptionIfTheEntityNouFound = true
            ) where TEntity : Model;

        public Task<IEnumerable<TEntity>> ToList<TEntity>(
         Expression<Func<TEntity, bool>>? where = null,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null,
         bool? tracking = null,
         bool evenDeleted = true)
         where TEntity : Model;

        public Task ThrowIfAnEntityFound<TEntity>
            (Expression<Func<TEntity, bool>> where) where TEntity : Model;

        #endregion
    }
}
