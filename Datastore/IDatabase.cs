using XSwift.Domain;
using Microsoft.EntityFrameworkCore;

namespace XSwift.Datastore
{
    public interface IDatabase
    {
        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext;

        #region Handle the commands of requests
        public Task CreateAsync<TRequest, TEntity>(
            TRequest request, TEntity entity)
            where TRequest : RequestToCreate<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task UpdateAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToUpdate<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task ArchiveAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToArchive<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task RestoreAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToRestore<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task DeleteAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToDelete<TEntity>
            where TEntity : BaseEntity<TEntity>;

        #endregion

        #region Handle the query based requests

        public Task<bool> AnyAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : AnyRequest<TEntity> 
            where TEntity : BaseEntity<TEntity>;

        public Task<TEntity?> GetItemAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : QueryItemRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<TModel?> GetItemAsync<TRequest, TEntity, TModel>(
            TRequest request,
            Converter<TEntity, TModel> converter)
            where TRequest : QueryItemRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;
        public Task<TModel?> GetItemAsync<TRequest, TEntity, TModel>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TModel>> selector)
            where TRequest : QueryItemRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<List<TEntity>> GetListAsync<TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<List<TModel>> GetListAsync<TRequest, TEntity, TModel>(
            TRequest request,
            Converter<TEntity, TModel> converter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;
        public Task<List<TModel>> GetListAsync<TRequest, TEntity, TModel>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TModel>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<PaginatedViewModel<TEntity>> GetPaginatedListAsync<
            TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;
        public Task<PaginatedViewModel<TModel>> GetPaginatedListAsync<
            TRequest, TEntity, TModel>(
            TRequest request,
            Converter<TEntity, TModel> converter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;
        public Task<PaginatedViewModel<TModel>> GetPaginatedListAsync<
            TRequest, TEntity, TModel>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TModel>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;
        #endregion

        #region Query Operations
        public IQueryable<TSource> MakeQuery<
            TRequest, TSource>(
            TRequest request)
            where TRequest : QueryRequest<TSource>
            where TSource : class;

        public IQueryable<TSource> SkipQuery<TSource>(
            IQueryable<TSource> query, int? pageNumber, int? pageSize)
            where TSource : class;
        #endregion

        #region Handle the invariants of requests
        public Task CheckInvariantsAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : ModelBasedRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;
        #endregion
    }
}
