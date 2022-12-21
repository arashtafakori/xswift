﻿using Microsoft.EntityFrameworkCore;
using SoftDeleteServices.Concrete;
using SoftDeleteServices.Configuration;
using System.Linq.Expressions;

namespace CoreX.Structure
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
        public async Task Create<TEntity>(TEntity entity,
            Expression<Func<TEntity, bool>>? noCreateWhere = null) where TEntity : Model
        {
            var _dbSet = _context.Set<TEntity>();

            if (noCreateWhere != null)
                await ThrowIfAnEntityFound(noCreateWhere);

            _dbSet.Add(entity);
        }

        public async Task Update<TEntity>(TEntity entity,
            Expression<Func<TEntity, bool>>? noUpdateWhere = null) where TEntity : Model
        {
            if (noUpdateWhere != null)
                await ThrowIfAnEntityFound(noUpdateWhere);
        }

        #endregion

        #region delete
        public async Task Delete<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ICascadeSoftDelete> configCascadeDelete,
            Expression<Func<TEntity, bool>>? noDeleteWhere = null) where TEntity : AggregateRoot
        {
            if (noDeleteWhere != null)
                await ThrowIfAnEntityFound(noDeleteWhere);

            var service = new CascadeSoftDelServiceAsync<ICascadeSoftDelete>(configCascadeDelete);
            await service.SetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }

        public async Task UndoDeleting<TEntity>(
            TEntity entity,
            CascadeSoftDeleteConfiguration<ICascadeSoftDelete> configCascadeDelete,
            Expression<Func<TEntity, bool>>? noUndoDeletingWhere = null) 
            where TEntity : AggregateRoot
        {
            if (noUndoDeletingWhere != null)
                await ThrowIfAnEntityFound(noUndoDeletingWhere);

            var service = new CascadeSoftDelServiceAsync<ICascadeSoftDelete>(configCascadeDelete);
            await service.ResetCascadeSoftDeleteAsync(entity, callSaveChanges: false);
        }

        public async Task<bool> IsValidToHardDelete<TEntity>(
             TEntity entity,
            CascadeSoftDeleteConfiguration<ICascadeSoftDelete> configCascadeDelete)
            where TEntity : AggregateRoot
        {
            var service = new CascadeSoftDelServiceAsync<ICascadeSoftDelete>(configCascadeDelete);
            return (await service.CheckCascadeSoftDeleteAsync(entity)).IsValid;
        }

        public async Task HardDelete<TEntity>(
            TEntity entity, Expression<Func<TEntity, bool>>? noDeleteWhere = null) 
            where TEntity : Model
        {
            if (noDeleteWhere != null)
                await ThrowIfAnEntityFound(noDeleteWhere);

            var _dbSet = _context.Set<TEntity>();
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
        public async Task HardDelete<TEntity>(
            Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>>? noDeleteWhere = null)
            where TEntity : Model
        {
            // if entity implements ICascadeSoftDelete interface, check entity that has to valid.

            //if (noDeleteWhere != null)
            //    await ThrowIfEntityIsExists(noDeleteWhere);

            throw new NotImplementedException();
        }

        #endregion

        #region retrieve
        public async Task<TEntity> Single<TEntity>(
          Expression<Func<TEntity, bool>> where,
          Expression<Func<TEntity, object>>? include = null,
          bool? tracking = null,
          bool evenDeleted = false,
          bool throwExceptionIfTheEntityNouFound = true) 
            where TEntity : Model
        {
            if (tracking == null)
                tracking = _tracking;

            return await _context.Single(
                where,
                include: include,
                tracking: tracking, 
                evenDeleted: evenDeleted,
                throwExceptionIfTheEntityNouFound: throwExceptionIfTheEntityNouFound);
        }

        public async Task<TEntity> Find<TEntity>(
            object[] KeyValues,
            bool throwExceptionIfTheEntityNouFound = true
            ) where TEntity : Model
        {
            return await _context.Find<TEntity>(
                throwExceptionIfTheEntityNouFound: throwExceptionIfTheEntityNouFound, KeyValues);
        }

        public async Task<TEntity> Find<TEntity>(
           object KeyValue,
           bool throwExceptionIfTheEntityNouFound = true
           ) where TEntity : Model
        {
            return await _context.Find<TEntity>(
                throwExceptionIfTheEntityNouFound: throwExceptionIfTheEntityNouFound, KeyValues: KeyValue);
        }

        public virtual async Task<IEnumerable<TEntity>> ToList<TEntity>(
         Expression<Func<TEntity, bool>>? where = null,
         Expression<Func<TEntity, object>>? orderBy = null,
         Expression<Func<TEntity, object>>? orderByDescending = null,
         Expression<Func<TEntity, object>>? include = null,
         bool? tracking = null,
         bool evenDeleted = true) where TEntity : Model
        {
            if (tracking == null)
                tracking = _tracking;

            return await _context.ToList(
                where: where,
                orderBy: orderBy,
                orderByDescending: orderByDescending,
                include: include,
                tracking: tracking,
                evenDeleted: evenDeleted);
        }
        public async Task ThrowIfAnEntityFound<TEntity>(Expression<Func<TEntity, bool>> where)
            where TEntity : Model
        {
            await DbContextExtensions.ThrowIfAnEntityFound(_context, where);
        }

        #endregion
    }
}