using XSwift.Domain;
using Microsoft.EntityFrameworkCore;

namespace XSwift.Datastore
{
    public interface IDatabase
    {
        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext;

        #region Handle the commands of requests
        public Task CreateAsync<TRequest, TEntity, TReturnedType>(
            TRequest request, TEntity entity)
            where TRequest : RequestToCreate<TEntity, TReturnedType>
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
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : AnyRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<TEntity?> GetItemAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : QueryItemRequest<TEntity, TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<TReturnedType?> GetItemAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Converter<TEntity, TReturnedType> converter)
            where TRequest : QueryItemRequest<TEntity, TReturnedType>
            where TEntity : BaseEntity<TEntity>;
        public Task<TReturnedType?> GetItemAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TReturnedType>> selector)
            where TRequest : QueryItemRequest<TEntity, TReturnedType>
            where TEntity : BaseEntity<TEntity>;

        public Task<List<TEntity>> GetListAsync<TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, TEntity>
            where TEntity : BaseEntity<TEntity>;

        public Task<List<TReturnedType>> GetListAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Converter<TEntity, TReturnedType> converter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, List<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;
        public Task<List<TReturnedType>> GetListAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TReturnedType>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, List<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;

        public Task<PaginatedViewModel<TEntity>> GetPaginatedListAsync<
            TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, PaginatedViewModel<TEntity>>
            where TEntity : BaseEntity<TEntity>;
        public Task<PaginatedViewModel<TReturnedType>> GetPaginatedListAsync<
            TRequest, TEntity, TReturnedType>(
            TRequest request,
            Converter<TEntity, TReturnedType> converter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, PaginatedViewModel<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;
        public Task<PaginatedViewModel<TReturnedType>> GetPaginatedListAsync<
            TRequest, TEntity, TReturnedType>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TReturnedType>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, PaginatedViewModel<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;
        #endregion
    }
}
