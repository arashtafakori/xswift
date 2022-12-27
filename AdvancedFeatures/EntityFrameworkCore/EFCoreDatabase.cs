using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Concrete;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace Artaco.Infrastructure.CoreX
{
    public abstract class EFCoreDatabase : IDatabase
    {
        private bool _tracking = true;
        public bool Tracking { get { return _tracking; } }
        private readonly DbContext _context;

        public EFCoreDatabase(DbContext context)
        {
            _context = context;
        }

        public TDbContext GetDbContext<TDbContext>() where TDbContext : DbContext
        {
            return (TDbContext)_context;
        }

        public void AsNoTraking()
        {
            _tracking = false;
        }

        #region create Update
        public async Task CreateAsync<TEntity>(TEntity entity,
            Expression<Func<TEntity, bool>>? noCreateWhere = null) where TEntity : BaseEntity
        {
            var _dbSet = _context.Set<TEntity>();

            if (noCreateWhere != null)
                await ThrowIfTheEntityWasNotFound(noCreateWhere);

            _dbSet.Add(entity);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity,
            Expression<Func<TEntity, bool>>? noUpdateWhere = null) where TEntity : BaseEntity
        {
            if (noUpdateWhere != null)
                await ThrowIfTheEntityWasNotFound(noUpdateWhere);
        }

        #endregion

        #region delete
        public async Task DeleteAsync<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete,
            Expression<Func<TEntity, bool>>? noDeleteWhere = null) where TEntity : BaseEntity
        {
            if (noDeleteWhere != null)
                await ThrowIfTheEntityWasNotFound(noDeleteWhere);

            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(configCascadeDelete);
            await service.SetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }

        public async Task UndoDeletingAsync<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete,
            Expression<Func<TEntity, bool>>? noUndoDeletingWhere = null) 
            where TEntity : BaseEntity
        {
            if (noUndoDeletingWhere != null)
                await ThrowIfTheEntityWasNotFound(noUndoDeletingWhere);

            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(configCascadeDelete);
            await service.ResetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }

        public async Task<bool> IsValidToHardDelete<TEntity>(
             TEntity entity,
            CascadeSoftDeleteConfiguration<ISoftDelete> configCascadeDelete)
            where TEntity : BaseEntity
        {
            var service = new CascadeSoftDelServiceAsync<ISoftDelete>(configCascadeDelete);
            return (await service.CheckCascadeSoftDeleteAsync(entity)).IsValid;
        }

        public async Task HardDeleteAsync<TEntity>(
            TEntity entity, Expression<Func<TEntity, bool>>? noDeleteWhere = null) 
            where TEntity : BaseEntity
        {
            if (noDeleteWhere != null)
                await ThrowIfTheEntityWasNotFound(noDeleteWhere);

            var _dbSet = _context.Set<TEntity>();
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
        public async Task HardDeleteAsync<TEntity>(
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>>? noDeleteWhere = null)
            where TEntity : BaseEntity
        {
            // if entity implements ICascadeSoftDelete interface, check entity that has to valid.

            //if (noDeleteWhere != null)
            //    await ThrowIfEntityIsExists(noDeleteWhere);

            throw new NotImplementedException();
        }

        #endregion

        #region retrieve
        public async Task<TEntity> SingleAsync<TEntity>(
          Expression<Func<TEntity, bool>> where,
          Expression<Func<TEntity, object>>? include = null,
          bool? tracking = null,
          bool evenTheDeletedOnes = false,
          bool throwExceptionIfTheEntityNouFound = true) 
            where TEntity : BaseEntity
        {
            if (tracking == null)
                tracking = _tracking;

            return await _context.SingleAsync(
                where,
                include: include,
                tracking: tracking,
                evenTheDeletedOnes: evenTheDeletedOnes,
                throwExceptionIfTheEntityNouFound: throwExceptionIfTheEntityNouFound);
        }

        public async Task<TEntity> FindAsync<TEntity>(
            object[] KeyValues,
            bool throwExceptionIfTheEntityNouFound = true
            ) where TEntity : BaseEntity
        {
            return await _context.FindAsync<TEntity>(
                throwExceptionIfTheEntityNouFound: throwExceptionIfTheEntityNouFound, KeyValues);
        }

        public async Task<TEntity> FindAsync<TEntity>(
           object KeyValue,
           bool throwExceptionIfTheEntityNouFound = true
           ) where TEntity : BaseEntity
        {
            return await _context.FindAsync<TEntity>(
                throwExceptionIfTheEntityNouFound: throwExceptionIfTheEntityNouFound, KeyValues: KeyValue);
        }

        public virtual async Task<IEnumerable<TEntity>> ToListAsync<TEntity>(
         Expression<Func<TEntity, bool>>? where = null,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null,
         bool? tracking = null,
         bool evenTheDeletedOnes = true) where TEntity : BaseEntity
        {
            if (tracking == null)
                tracking = _tracking;

            return await _context.ToListAsync(
                where: where,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                tracking: tracking,
                evenTheDeletedOnes: evenTheDeletedOnes);
        }
        public async Task ThrowIfTheEntityWasNotFound<TEntity>(Expression<Func<TEntity, bool>> where)
            where TEntity : BaseEntity
        {
            await DbContextExtensions.ThrowIfTheEntityWasNotFound(_context, where);
        }

        #endregion
    }
}
