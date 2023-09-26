using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class QueryRequest<TEntity> :
        ModelBasedRequest<TEntity>
    {
        public bool EvenArchivedData { get; set; } = false;
        public virtual bool OnIncludingArchivedDataConfiguration()
        {
            return EvenArchivedData;
        }
        /// <summary>
        /// If the pageSize parameter is zero, 
        /// it means that there is not any pagination
        /// </summary>
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public PaginationSetting? PaginationSetting { get; private set; }

        public void Setup(PaginationSetting paginationSetting)
        {
            if (paginationSetting == null)
                return;

            PaginationSetting = paginationSetting;

            PageNumber ??= PaginationSetting.DefaultPageNumber;
            PageSize ??= PaginationSetting.DefaultPageSize;
        }
        public bool PreventIfNoEntityWasFound { get; set; } = false;
        public bool TrackingMode { get; set; } = false;


        public virtual Expression<Func<TEntity, object>>? OrderBy()
        {
            return null;
        }
        public virtual Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return null;
        }
        public virtual Expression<Func<TEntity, object>>? Include()
        {
            return null;
        }
    }
}
