using CoreX.Base;
using CoreX.Datastore;
using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Concrete;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace EntityFrameworkCore.CoreX.Datastore
{
    public static class DatabaseExtensions
    {
        public static void AddSoftDeleteConfiguration(
            this Database database, CascadeSoftDeleteConfiguration<ISoftDelete> softDeleteConfiguration)
        {
            if (database._softDeleteConfiguration == null)
                database._softDeleteConfiguration = softDeleteConfiguration;
        }
    }

    public abstract class Database : IDatabase
    {
        public Database(DbContext context)
        {
            _context = context;
        }

        private bool _trackingMode = true;
        public bool TrackingMode { get { return _trackingMode; } }
        private readonly DbContext _context;

        public CascadeSoftDeleteConfiguration<ISoftDelete>? _softDeleteConfiguration;

        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext
        {
            return (TDbContext)_context;
        }

        public void AsNoTraking()
        {
            _trackingMode = false;
        }

        #region Creating and updating methods
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
            var builder = new ExpressionBuilder<TEntity>();
            builder.And(builder.Invert(condition));
            if (uniqueSpecification != null)
                builder.And(uniqueSpecification);
            var expression = builder.GetExpression();

            if (uniqueSpecification != null)
                await _context.ThrowIfTheEntityWithThisSpecificationHasAlreadyBeenExisted(expression);
        }
        #endregion

        #region Archiving an restoring methods
        public async Task ArchiveAsync<TEntity>(TEntity entity) 
            where TEntity : BaseEntity
        {
            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(_softDeleteConfiguration);
            await service.SetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }
        public async Task ArchiveAsync<TEntity>(List<TEntity> entities)
            where TEntity : BaseEntity
        {
            foreach (var entity in entities)
                await ArchiveAsync(entity);
        }

        public async Task RestoreAsync<TEntity>(
            List<TEntity> entities,
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null) 
            where TEntity : BaseEntity
        {
            foreach (var entity in entities)
                await RestoreAsync(entity, condition);
        }
        public async Task RestoreAsync<TEntity>(
            TEntity entity,
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, bool>>? uniqueSpecification = null)
            where TEntity : BaseEntity
        {
            var builder = new ExpressionBuilder<TEntity>();
            builder.And(builder.Invert(condition));
            if (uniqueSpecification != null)
                builder.And(uniqueSpecification);
            var expression = builder.GetExpression();
            if (expression != null)
                await _context.ThrowIfTheEntityWithThisSpecificationHasAlreadyBeenExisted(expression);

            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(_softDeleteConfiguration);
            await service.ResetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }

        #endregion

        #region deleting methods
        private async Task<bool> CanDelete<TEntity>(TEntity entity)
            where TEntity : BaseEntity
        {
            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(_softDeleteConfiguration);
            return (await service.CheckCascadeSoftDeleteAsync(entity)).IsValid;
        }
        public async Task DeleteAsync<TEntity>(
            TEntity entity) 
            where TEntity : BaseEntity
        {
            await CanDelete(entity);

            var _dbSet = _context.Set<TEntity>();
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync<TEntity>(
            List<TEntity> entities)
            where TEntity : BaseEntity
        {
            foreach (var entity in entities)
                await DeleteAsync(entity);
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
                evenArchivedData: request.OnIncludingArchivedDataConfiguration(),include: request.Include());
        }
        public async Task<bool> AnyAsync<TEntity>(
            Expression<Func<TEntity, bool>>? condition,
            bool evenArchivedData = false,
            Expression<Func<TEntity, object>>? include = null)
            where TEntity : BaseEntity
        {
            return await _context.AnyAsync(
                condition: condition,
                include: include,
                evenArchivedData: evenArchivedData);
        }

        public async Task<TEntity?> GetEntityAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : RetrivalRequest<TEntity>
            where TEntity : BaseEntity
        {
            return await GetEntityAsync(
                condition: request.Condition(),
                trackingMode: request.TrackingMode,
                evenArchivedData: request.OnIncludingArchivedDataConfiguration(),
                throwExceptionIfEntityWasNotFound: request.ThrowExceptionIfEntityWasNotFound,
                include: request.Include());
        }
        public async Task<TEntity> GetEntityAsync<TEntity>(
            Expression<Func<TEntity, bool>>? condition,
            bool? trackingMode = null,
            bool? evenArchivedData = false,
            bool throwExceptionIfEntityWasNotFound = false,
            Expression<Func<TEntity, object>>? include = null)
            where TEntity : BaseEntity
        {
            if (trackingMode == null)
                trackingMode = _trackingMode;

            return await _context.GetEntityAsync(
                condition: condition,
                include: include,
                trackingMode: trackingMode!,
                evenArchivedData: evenArchivedData,
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
                evenArchivedData: request.OnIncludingArchivedDataConfiguration(),
                throwExceptionIfEntityWasNotFound: request.ThrowExceptionIfEntityWasNotFound,
                orderBy: request.OrderBy(),
                orderByDescending: request.OrderByDescending(),
                include: request.Include());
        }

        public async Task<List<TEntity>> GetEntitiesAsync<TEntity>(
         Expression<Func<TEntity, bool>>? condition,
         bool? trackingMode = null,
         bool? evenArchivedData = false,
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
                evenArchivedData: evenArchivedData,
                throwExceptionIfEntityWasNotFound: throwExceptionIfEntityWasNotFound);
        }

        #endregion
    }
}
