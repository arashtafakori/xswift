using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreX.Datastore
{
    public interface IDatabase
    {
        public bool TrackingMode { get; }
        public void AsNoTraking();
        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext;

        #region Creating and updating methods
        public Task CreateAsync<TEntity>
            (TEntity entity,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;

        public Task UpdateAsync<TEntity>
            (Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;
        #endregion

        #region Archiving an restoring methods
        public Task ArchiveAsync<TEntity>(TEntity entity)
            where TEntity : BaseEntity;
        public Task ArchiveAsync<TEntity>(List<TEntity> entities)
            where TEntity : BaseEntity;

        public Task RestoreAsync<TEntity>
            (List<TEntity> entities,
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;
        public Task RestoreAsync<TEntity>
            (TEntity entity,
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity;
        #endregion

        #region deleting methods
        public Task DeleteAsync<TEntity>
            (TEntity entity)
            where TEntity : BaseEntity;
        public Task DeleteAsync<TEntity>(
            List<TEntity> entities)
            where TEntity : BaseEntity;
        #endregion

        #region Retrieval methods

        public Task<bool> AnyAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : AnyRequest<TEntity> where TEntity : BaseEntity;

        public Task<bool> AnyAsync<TEntity>(
          Expression<Func<TEntity, bool>> condition,
          bool evenArchivedData = false,
          Expression<Func<TEntity, object>>? include = null)
          where TEntity : BaseEntity;

        public Task<TEntity?> GetEntityAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalRequest<TEntity>
            where TEntity : BaseEntity;

        public Task<TEntity?> GetEntityAsync<TEntity>(
            Expression<Func<TEntity, bool>> condition,
            bool? trackingMode = false,
            bool? evenArchivedData = false,
            bool throwExceptionIfEntityWasNotFound = false,
            Expression<Func<TEntity, object>>? include = null)
            where TEntity : BaseEntity;

        public Task<List<TEntity>> GetEntitiesAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalEntitiesRequest<TEntity> where TEntity : BaseEntity;

        public Task<List<TEntity>> GetEntitiesAsync<TEntity>(
         Expression<Func<TEntity, bool>> condition,
         bool? trackingMode = false,
         bool? evenArchivedData = false,
         bool throwExceptionIfEntityWasNotFound = false,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null,
         int offset = 0,
         int limit = 0)
         where TEntity : BaseEntity;

        #endregion
    }
}
