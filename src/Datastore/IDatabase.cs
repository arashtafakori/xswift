using XSwift.Domain;
using Microsoft.EntityFrameworkCore;

namespace XSwift.Datastore
{
    /// <summary>
    /// Represents the interface for interacting with the database, providing methods to handle both command and query operations.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets a database context of the specified type.
        /// </summary>
        /// <typeparam name="TDbContext">The type of the database context.</typeparam>
        /// <returns>An instance of the specified database context type.</returns>
        public TDbContext GetDbContext<TDbContext>() 
            where TDbContext : DbContext;

        /// <summary>
        /// Ensures that the database is recreated.
        /// </summary>
        public void EnsureRecreated();

        /// <summary>
        /// Ensures that the database is recreated asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task EnsureRecreatedAsync();

        #region Handle the commands of requests

        /// <summary>
        /// Creates a new entity in the database based on the provided request and entity.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to create the entity.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to be created.</typeparam>
        /// <typeparam name="TReturnedType">The type of the returned result, if any.</typeparam>
        /// <param name="request">The request containing information for creating the entity.</param>
        /// <param name="entity">The entity to be created.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task CreateAsync<TRequest, TEntity, TReturnedType>(
            TRequest request, TEntity entity)
            where TRequest : RequestToCreate<TEntity, TReturnedType>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Updates an existing entity in the database based on the provided request and entity.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to update the entity.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to be updated.</typeparam>
        /// <param name="request">The request containing information for updating the entity.</param>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToUpdate<TEntity>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Archives an entity in the database based on the provided request and entity.
        /// The archiving operation is assumed to be soft deletion.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to archive the entity.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to be archived.</typeparam>
        /// <param name="request">The request containing information for archiving the entity.</param>
        /// <param name="entity">The entity to be archived.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task ArchiveAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToArchive<TEntity>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Restores an archived entity in the database based on the provided request and entity.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to restore the entity.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to be restored.</typeparam>
        /// <param name="request">The request containing information for restoring the entity.</param>
        /// <param name="entity">The entity to be restored.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task RestoreAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToRestore<TEntity>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Deletes an entity from the database based on the provided request and entity.
        /// The deletion operation is assumed to be physical or hard deletion.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to delete the entity.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to be deleted.</typeparam>
        /// <param name="request">The request containing information for deleting the entity.</param>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteAsync<TRequest, TEntity>
            (TRequest request, TEntity entity)
            where TRequest : RequestToDelete<TEntity>
            where TEntity : BaseEntity<TEntity>;

        #endregion

        #region Handle the query based requests

        /// <summary>
        /// Checks if any entities in the database match the specified criteria based on the request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating if any entities match the criteria.</returns>
        public Task<bool> AnyAsync<TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : AnyRequest<TEntity>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a single entity from the database based on the specified request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a single entity or null if not found.</returns>
        public Task<TEntity?> GetItemAsync<TRequest, TEntity>(
            TRequest request)
            where TRequest : QueryItemRequest<TEntity, TEntity>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a transformed result of a single entity from the database based on the specified request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <typeparam name="TReturnedType">The type of the transformed result.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="converter">The converter function to transform the entity result.</param>
        /// <returns>A task representing the asynchronous operation, returning a transformed result or null if not found.</returns>
        public Task<TReturnedType?> GetItemAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Converter<TEntity, TReturnedType> converter)
            where TRequest : QueryItemRequest<TEntity, TReturnedType>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a transformed result of a single entity from the database based on the specified request using a custom selector.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <typeparam name="TReturnedType">The type of the transformed result.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="selector">The selector function to transform the entity result based on the database models.</param>
        /// <returns>A task representing the asynchronous operation, returning a transformed result or null if not found.</returns>
        public Task<TReturnedType?> GetItemAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TReturnedType>> selector)
            where TRequest : QueryItemRequest<TEntity, TReturnedType>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a list of entities from the database based on the specified request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of entities.</returns>
        public Task<List<TEntity>> GetListAsync<TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, TEntity>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a list of transformed results from the database based on the specified request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <typeparam name="TReturnedType">The type of the transformed result.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="converter">The converter function to transform each entity result.</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of transformed results.</returns>
        public Task<List<TReturnedType>> GetListAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Converter<TEntity, TReturnedType> converter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, List<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a list of transformed results from the database based on the specified request using a custom selector.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <typeparam name="TReturnedType">The type of the transformed result.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="selector">The selector function to transform each entity result based on the database models..</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of transformed results.</returns>
        public Task<List<TReturnedType>> GetListAsync<TRequest, TEntity, TReturnedType>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TReturnedType>> selector,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, List<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a paginated list of entities from the database based on the specified request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a paginated view of entities.</returns>
        public Task<PaginatedViewModel<TEntity>> GetPaginatedListAsync<
            TRequest, TEntity>(
            TRequest request,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, PaginatedViewModel<TEntity>>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a paginated list of transformed results from the database based on the specified request.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <typeparam name="TReturnedType">The type of the transformed result.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="converter">The converter function to transform each entity result.</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a paginated view of transformed results.</returns>
        public Task<PaginatedViewModel<TReturnedType>> GetPaginatedListAsync<
            TRequest, TEntity, TReturnedType>(
            TRequest request,
            Converter<TEntity, TReturnedType> converter,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null)
            where TRequest : QueryListRequest<TEntity, PaginatedViewModel<TReturnedType>>
            where TEntity : BaseEntity<TEntity>;

        /// <summary>
        /// Gets a paginated list of transformed results from the database based on the specified request using a custom selector.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request for the query.</typeparam>
        /// <typeparam name="TEntity">The type of the entity to query.</typeparam>
        /// <typeparam name="TReturnedType">The type of the transformed result.</typeparam>
        /// <param name="request">The request containing information for the query.</param>
        /// <param name="selector">The selector function to transform each entity result based on the database models.</param>
        /// <param name="filter">Optional filter to further narrow down the query.</param>
        /// <returns>A task representing the asynchronous operation, returning a paginated view of transformed results.</returns>
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
