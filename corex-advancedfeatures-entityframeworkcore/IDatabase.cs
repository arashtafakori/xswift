using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace CoreX.AdvancedFeatures.EntityFrameworkCore
{
    public interface IDatabase
    {
        public bool TrackingMode { get; }
        public void AsNoTraking();
        public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext;

        #region create Update

        public Task CreateAsync<TEntity>
            (TEntity entity,
            Expression<Func<TEntity, bool>>? preExistingCondition = null)
            where TEntity : BaseEntity;

        public Task UpdateAsync<TEntity>
            (Expression<Func<TEntity, bool>>? preExistingCondition = null)
            where TEntity : BaseEntity;

        #endregion

        #region delete
        public Task DeleteAsync<TEntity>
            (TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
            where TEntity : BaseEntity;

        public Task UndoDeletingAsync<TEntity>
            (TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration,
            Expression<Func<TEntity, bool>>? preExistingCondition = null)
            where TEntity : BaseEntity;

        public Task<bool> IsValidToDeletePhysically<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete)
            where TEntity : BaseEntity;

        public Task DeletePhysically<TEntity>
            (TEntity entity)
            where TEntity : BaseEntity;
        public Task DeletePhysicallyAsync<TEntity>
            (Expression<Func<TEntity, bool>> condition)
            where TEntity : BaseEntity;
        #endregion

        #region retrieve
        public Task<TEntity> SingleAsync<TEntity>(
          Expression<Func<TEntity, bool>> where,
          Expression<Func<TEntity, object>>? include = null,
          bool? trackingMode = null,
          bool alsoTheDeletedOnes = false,
          bool throwExceptionIfEntityWasNotFound = false)
          where TEntity : BaseEntity;

        public Task<TEntity> FindAsync<TEntity>(
            object[] KeyValues,
            bool throwExceptionIfEntityWasNotFound = false
            ) where TEntity : BaseEntity;

        public Task<TEntity> FindAsync<TEntity>(
            object KeyValue,
            bool throwExceptionIfEntityWasNotFound = false
            ) where TEntity : BaseEntity;

        public Task<IEnumerable<TEntity>> ToListAsync<TEntity>(
         Expression<Func<TEntity, bool>>? condition = null,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null,
         bool? trackingMode = null,
         bool alsoTheDeletedOnes = true)
         where TEntity : BaseEntity;

        #endregion
    }
}
