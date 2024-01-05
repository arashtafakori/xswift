using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for query requests with optional pagination settings.
    /// </summary>
    /// <typeparam name="TReturnedType">The type of the result returned by the query.</typeparam>
    public abstract class BaseQueryRequest<TReturnedType> :
        BaseRequest, IRequest<TReturnedType>
    {
        /// <summary>
        /// Gets or sets the page number for pagination.
        /// If the pageNumber is null, It means that all records will be included.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size for pagination.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets the pagination setting associated with the query request.
        /// </summary>
        public PaginationSetting? PaginationSetting { get; private set; }

        /// <summary>
        /// Sets up the pagination setting for the query request.
        /// </summary>
        /// <param name="paginationSetting">The pagination setting to apply.</param>
        public void Setup(PaginationSetting paginationSetting)
        {
            if (paginationSetting == null)
                return;

            PaginationSetting = paginationSetting;

            PageNumber ??= PaginationSetting.DefaultPageNumber;
            PageSize ??= PaginationSetting.DefaultPageSize;
        }

        /// <summary>
        /// Asynchronously resolves the query using the provided mediator.
        /// </summary>
        /// <param name="mediator">The mediator used to resolve the query.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task ResolveAsync(IMediator mediator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously handles the next step in the query processing using the provided mediator and returned value.
        /// </summary>
        /// <param name="mediator">The mediator used to handle the next step.</param>
        /// <param name="returnedValue">The returned value from the previous step.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async virtual Task NextAsync(IMediator mediator, TReturnedType returnedValue)
        {
            throw new NotImplementedException();
        }
    }
}
