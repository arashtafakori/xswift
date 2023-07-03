using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace EntityFrameworkCore.CoreX
{
    public interface IDatabase
    {
        public bool TrackingMode { get; }
        public void AsNoTraking();
        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext;

        #region Creation and updation methods

        public Task CreateAsync<TEntity>
            (TEntity entity,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;

        public Task UpdateAsync<TEntity>
            (Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;
        #endregion

        #region Soft deletion methods
        public Task DeleteAsync<TEntity>
            (TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
            where TEntity : BaseEntity;
        public Task DeleteAsync<TEntity>
            (List<TEntity> entities,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
            where TEntity : BaseEntity;
        //public Task DeleteAsync<TEntity>
        //    (Expression<Func<TEntity, bool>> condition,
        //    CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
        //    where TEntity : BaseEntity;


        public Task UndoDeletingAsync<TEntity>
            (List<TEntity> entities,
            Expression<Func<TEntity, bool>> condition,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;
        public Task UndoDeletingAsync<TEntity>
            (TEntity entity,
            Expression<Func<TEntity, bool>> condition,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;
        //public Task UndoDeletingAsync<TEntity>
        //    (Expression<Func<TEntity, bool>> condition,
        //    CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration,
        //    Expression<Func<TEntity, bool>>? uniqueSpecification = null)
        //    where TEntity : BaseEntity;
        #endregion

        #region Hard deletion methods
        public Task<bool> CanDeleteHardly<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
            where TEntity : BaseEntity;

        public Task DeleteHardlyAsync<TEntity>
            (TEntity entity)
            where TEntity : BaseEntity;

        //public Task<bool> CanDeleteHardly<TEntity>(
        //    List<TEntity> entities,
        //    CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
        //    where TEntity : BaseEntity;
        //public Task DeleteHardlyAsync<TEntity>
        //    (List<TEntity> entities)
        //    where TEntity : BaseEntity;

        // if the entity implements ICascadeSoftDelete interface,
        // It muse be checked out for validation.
        //public Task DeleteHardlyAsync<TEntity>
        //    (Expression<Func<TEntity, bool>> condition)
        //    where TEntity : BaseEntity;
        #endregion

        #region Retrieval methods

        public Task<bool> AnyAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : AnyRequest<TEntity> where TEntity : BaseEntity;

        public Task<bool> AnyAsync<TEntity>(
          Expression<Func<TEntity, bool>> condition,
          bool includedArchivedEntities = false,
          Expression<Func<TEntity, object>>? include = null)
          where TEntity : BaseEntity;

        public Task<TEntity?> GetEntityAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalRequest<TEntity>
            where TEntity : BaseEntity;

        public Task<TEntity> GetEntityAsync<TEntity>(
            Expression<Func<TEntity, bool>> condition,
            bool? trackingMode = false,
            bool? includedArchivedEntities = false,
            bool throwExceptionIfEntityWasNotFound = false,
            Expression<Func<TEntity, object>>? include = null)
            where TEntity : BaseEntity;

        public Task<List<TEntity>> GetEntitiesAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalEntitiesRequest<TEntity> where TEntity : BaseEntity;

        public Task<List<TEntity>> GetEntitiesAsync<TEntity>(
         Expression<Func<TEntity, bool>> condition,
         bool? trackingMode = false,
         bool? includedArchivedEntities = false,
         bool throwExceptionIfEntityWasNotFound = false,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null)
         where TEntity : BaseEntity;

        #endregion
    }
}
