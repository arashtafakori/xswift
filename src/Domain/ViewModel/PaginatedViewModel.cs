namespace XSwift.Domain
{
    /// <summary>
    /// Represents a paginated view model for a collection of items.
    /// </summary>
    /// <typeparam name="TModel">The type of items in the collection.</typeparam>
    public class PaginatedViewModel<TModel>
    {
        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int? PageNumber { get;private set; }

        /// <summary>
        /// Gets the number of items per page.
        /// </summary>
        public int? PageSize { get; private set; }

        /// <summary>
        /// Gets the total number of pages based on the total count of items and the page size.
        /// </summary>
        public int? TotalPages
        {
            get
            {
                if (PageSize != null)
                    return (int)Math.Ceiling(NumberOfTotalItems / (double)PageSize);
                
                return null;
            }
        }

        /// <summary>
        /// Gets the number of total items.
        /// </summary>
        public int NumberOfTotalItems { get; private set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;

        /// <summary>
        /// Gets or sets the list of items in the paginated view.
        /// </summary>
        public List<TModel> Items { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedViewModel{TModel}"/> class.
        /// </summary>
        /// <param name="items">The list of items in the paginated view.</param>
        /// <param name="numberOfTotalItems">The number of total items.</param>
        /// <param name="pageNumber">The current page number (optional).</param>
        /// <param name="pageSize">The number of items per page (optional).</param>
        public PaginatedViewModel(
            List<TModel> items,
            int numberOfTotalItems,
            int? pageNumber = null,
            int? pageSize = null)
        {
            Items = items;
            NumberOfTotalItems = numberOfTotalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
