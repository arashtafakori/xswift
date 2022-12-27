using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace Artaco.Infrastructure.CoreX
{
    public interface IDatabase
    {
        public bool Tracking { get; }
        public void AsNoTraking();
        public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext;

        #region create Update

        public Task CreateAsync<TEntity>
            (TEntity entity, Expression<Func<TEntity, bool>>? noCreateWhere = null)
            where TEntity : BaseEntity;

        public Task UpdateAsync<TEntity>
    (TEntity entity, Expression<Func<TEntity, bool>>? noUpdateWhere = null)
    where TEntity : BaseEntity;

        #endregion

        #region delete
        public Task DeleteAsync<TEntity>
    (TEntity entity, CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete,
    Expression<Func<TEntity, bool>>? noDeleteWhere = null) where TEntity : BaseEntity;

        public Task UndoDeletingAsync<TEntity>
            (TEntity entity, CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete,
            Expression<Func<TEntity, bool>>? noUndoDeletingWhere = null) where TEntity : BaseEntity;

        public Task<bool> IsValidToHardDelete<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete)
            where TEntity : BaseEntity;

        public Task HardDeleteAsync<TEntity>
            (TEntity entity, Expression<Func<TEntity, bool>>? noDeleteWhere = null) where TEntity : BaseEntity;
        public Task HardDeleteAsync<TEntity>
            (Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>>? noDeleteWhere = null)
            where TEntity : BaseEntity;

        //public async Task Delete<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task UndoDeleting<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task IsValidToHardDelete<TEntity>(Expression<Func<TEntity, bool>> where

        //public async Task DeleteViaKeys<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task UndoDeletingViaKeys<TEntity>(Expression<Func<TEntity, bool>> where
        //public async Task IsValidToHardDeleteViaKeys<TEntity>(Expression<Func<TEntity, bool>> where
        #endregion

        #region retrieve
        public Task<TEntity> SingleAsync<TEntity>(
          Expression<Func<TEntity, bool>> where,
          Expression<Func<TEntity, object>>? include = null,
          bool? tracking = null,
          bool evenTheDeletedOnes = false,
          bool throwExceptionIfTheEntityNouFound = true)
          where TEntity : BaseEntity;

        public Task<TEntity> FindAsync<TEntity>(
            object[] KeyValues,
            bool throwExceptionIfTheEntityNouFound = true
            ) where TEntity : BaseEntity;

        public Task<TEntity> FindAsync<TEntity>(
            object KeyValue,
            bool throwExceptionIfTheEntityNouFound = true
            ) where TEntity : BaseEntity;

        public Task<IEnumerable<TEntity>> ToListAsync<TEntity>(
         Expression<Func<TEntity, bool>>? where = null,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null,
         bool? tracking = null,
         bool evenTheDeletedOnes = true)
         where TEntity : BaseEntity;

        public Task ThrowIfTheEntityWasNotFound<TEntity>
            (Expression<Func<TEntity, bool>> where) where TEntity : BaseEntity;

        #endregion
    }
}
