namespace XSwift.Domain
{
    /// <summary>
    /// Represents the pagination settings used for controlling page number and page size.
    /// </summary>
    public class PaginationSetting
    {
        /// <summary>
        /// Gets the default page number.
        /// </summary>
        public int DefaultPageNumber { get; private set; }

        /// <summary>
        /// Gets the default page size.
        /// </summary>
        public int DefaultPageSize { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationSetting"/> class with default values.
        /// </summary>
        /// <param name="defaultPageNumber">The default page number. Default is 1.</param>
        /// <param name="defaultPageSize">The default page size. Default is 20.</param>
        public PaginationSetting(
            int defaultPageNumber = 1, 
            int defaultPageSize = 20)
        {
            DefaultPageNumber= defaultPageNumber;
            DefaultPageSize= defaultPageSize;
        }
    }
}
