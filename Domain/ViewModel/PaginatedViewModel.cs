namespace XSwift.Domain
{
    public class PaginatedViewModel<TModel>
    {
        public int? PageNumber { get;private set; }
        public int? PageSize { get; private set; }
        public int? TotalPages
        {
            get
            {
                if (PageSize != null)
                    return (int)Math.Ceiling(CountOfAllItems / (double)PageSize);
                
                return null;
            }
        }
        public int CountOfAllItems { get; private set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public List<TModel> Items { get; set; }

        public PaginatedViewModel(
            List<TModel> items,
            int countOfAllItems,
            int? pageNumber = null,
            int? pageSize = null)
        {
            Items = items;
            CountOfAllItems = countOfAllItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int? PreviousPageNumber => PageNumber - 1;
        public int? NextPageNumber => PageNumber + 1;
    }
}
