namespace CoreX.Domain
{
    public class PaginationSetting
    {
        public int DefaultPageNumber { get; private set; }
        public int DefaultPageSize { get; private set; }

        /// <summary>
        /// DefaultPageNumber is 1 as default.
        /// DefaultPageSize is 10 as default.
        /// </summary>
        public PaginationSetting(
            int defaultPageNumber = 1, 
            int defaultPageSize = 20)
        {
            DefaultPageNumber= defaultPageNumber;
            DefaultPageSize= defaultPageSize;
        }
    }
}
