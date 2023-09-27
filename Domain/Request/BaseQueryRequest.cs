namespace XSwift.Domain
{
    /// <summary>
    /// If the pageNumber is null, It means that all records  will be included.
    /// If the pageNumber is null, It means that the rest of records  
    /// which exist after the pageNumber as pageNumber will be included.
    /// </summary>
    public abstract class BaseQueryRequest : BaseRequest
    {        
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public PaginationSetting? PaginationSetting { get;private set; }

        public void Setup(PaginationSetting paginationSetting)
        {
            if (paginationSetting == null)
                return;

            PaginationSetting = paginationSetting;

            PageNumber ??= PaginationSetting.DefaultPageNumber;
            PageSize ??= PaginationSetting.DefaultPageSize;
        }
    }
}
