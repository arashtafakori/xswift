using CoreX.Base;
using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Concrete;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace EntityFrameworkCore.CoreX
{
    public abstract class Database : IDatabase
    {
        private bool _trackingMode = true;
        public bool TrackingMode { get { return _trackingMode; } }
        private readonly DbContext _context;

        public Database(DbContext context)
        {
            _context = context;
        }

        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext
        {
            return (TDbContext)_context;
        }

        public void AsNoTraking()
        {
            _trackingMode = false;
        }

        #region Creation and updation methods
        public async Task CreateAsync<TEntity>(
            TEntity entity,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity
        {
            var _dbSet = _context.Set<TEntity>();

            if (uniqueSpecification != null)
                await _context.ThrowIfTheEntityWithThisSpecificationHasAlreadyBeenExisted(uniqueSpecification);

            _dbSet.Add(entity);
        }

        public async Task UpdateAsync<TEntity>(
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity
        {
            var whereBuilder = new ExpressionBuilder<TEntity>();
            whereBuilder.And(condition);
            if (uniqueSpecification != null)
                whereBuilder.And(uniqueSpecification);
            var expression = whereBuilder.GetExpression();

            if (uniqueSpecification != null)
                await _context.ThrowIfTheEntityWithThisSpecificationHasAlreadyBeenExisted(expression);
        }
        #endregion

        #region Soft deletion methods
        public async Task DeleteAsync<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration) 
            where TEntity : BaseEntity
        {
            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(softDeleteConfiguration);
            await service.SetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }
        public async Task DeleteAsync<TEntity>(
            List<TEntity> entities, 
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
            where TEntity : BaseEntity
        {
            foreach (var entity in entities)
                await DeleteAsync(entity, softDeleteConfiguration);
        }

        public async Task UndoDeletingAsync<TEntity>(
            List<TEntity> entities,
            Expression<Func<TEntity, bool>> condition,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null) 
            where TEntity : BaseEntity
        {
            foreach (var entity in entities)
                await UndoDeletingAsync(entity, condition, softDeleteConfiguration);
        }
        public async Task UndoDeletingAsync<TEntity>(
            TEntity entity,
            Expression<Func<TEntity, bool>> condition,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity
        {
            var whereBuilder = new ExpressionBuilder<TEntity>();
            whereBuilder.And(condition);
            if (uniqueSpecification != null)
                whereBuilder.And(uniqueSpecification);
            var expression = whereBuilder.GetExpression();
            if (expression != null)
                await _context.ThrowIfTheEntityWithThisSpecificationHasAlreadyBeenExisted(expression);

            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(softDeleteConfiguration);
            await service.ResetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }

        #endregion

        #region Hard deletion methods
        public async Task<bool> CanDeleteHardly<TEntity>(
             TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
            where TEntity : BaseEntity
        {
            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(softDeleteConfiguration);
            return (await service.CheckCascadeSoftDeleteAsync(entity)).IsValid;
        }
        public async Task DeleteHardlyAsync<TEntity>(TEntity entity) 
            where TEntity : BaseEntity
        {

            var _dbSet = _context.Set<TEntity>();
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        #endregion

        #region Retrieval methods

        public async Task<bool> AnyAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : AnyRequest<TEntity>
            where TEntity : BaseEntity
        {
            return await AnyAsync(
                condition: request.Condition(),
                includedArchivedEntities: request.HasIncludedArchivedEntities(),include: request.Include());
        }
        public async Task<bool> AnyAsync<TEntity>(
            Expression<Func<TEntity, bool>>? condition,
            bool includedArchivedEntities = false,
            Expression<Func<TEntity, object>>? include = null)
            where TEntity : BaseEntity
        {
            return await _context.AnyAsync(
                condition: condition,
                include: include,
                includedArchivedEntities: includedArchivedEntities);
        }

        public async Task<TEntity?> GetEntityAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalRequest<TEntity>
            where TEntity : BaseEntity
        {
            return await GetEntityAsync(
                condition: request.Condition(),
                trackingMode: request.TrackingMode,
                includedArchivedEntities: request.HasIncludedArchivedEntities(),
                throwExceptionIfEntityWasNotFound: request.ThrowExceptionIfEntityWasNotFound,
                include: request.Include());
        }
        public async Task<TEntity> GetEntityAsync<TEntity>(
            Expression<Func<TEntity, bool>>? condition,
            bool? trackingMode = null,
            bool? includedArchivedEntities = false,
            bool throwExceptionIfEntityWasNotFound = false,
            Expression<Func<TEntity, object>>? include = null)
            where TEntity : BaseEntity
        {
            if (trackingMode == null)
                trackingMode = _trackingMode;

            return await _context.GetEntityAsync(
                condition: condition,
                include: include,
                trackingMode: trackingMode,
                includedArchivedEntities: includedArchivedEntities,
                throwExceptionIfEntityWasNotFound: throwExceptionIfEntityWasNotFound);
        }

        public async Task<List<TEntity>> GetEntitiesAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalEntitiesRequest<TEntity>
            where TEntity : BaseEntity
        {
            return await GetEntitiesAsync(
                condition: request.Condition(),
                trackingMode: request.TrackingMode,
                includedArchivedEntities: request.HasIncludedArchivedEntities(),
                throwExceptionIfEntityWasNotFound: request.ThrowExceptionIfEntityWasNotFound,
                orderBy: request.OrderBy(),
                orderByDescending: request.OrderByDescending(),
                include: request.Include());
        }

        public async Task<List<TEntity>> GetEntitiesAsync<TEntity>(
         Expression<Func<TEntity, bool>>? condition,
         bool? trackingMode = null,
         bool? includedArchivedEntities = false,
         bool throwExceptionIfEntityWasNotFound = false,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null) 
            where TEntity : BaseEntity
        {
            if (trackingMode == null)
                trackingMode = _trackingMode;

            return await _context.GetEntitiesAsync(
                condition: condition,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                trackingMode: trackingMode,
                includedArchivedEntities: includedArchivedEntities,
                throwExceptionIfEntityWasNotFound: throwExceptionIfEntityWasNotFound);
        }

        #endregion
    }
}
