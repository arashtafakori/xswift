using System.Linq.Expressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for queries associated with a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the query.</typeparam>
    public abstract class QueryRequest<TEntity> :
        EntityBasedRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Gets or sets the page number for pagination. If zero, it means there is no pagination.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size for pagination.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets the pagination setting used to configure default page number and page size.
        /// </summary>
        public PaginationSetting? PaginationSetting { get; private set; }

        /// <summary>
        /// Sets up the pagination settings based on the provided <paramref name="paginationSetting"/>.
        /// </summary>
        /// <param name="paginationSetting">The pagination setting to be used.</param>
        public void Setup(PaginationSetting paginationSetting)
        {
            if (paginationSetting == null)
                return;

            PaginationSetting = paginationSetting;

            PageNumber ??= PaginationSetting.DefaultPageNumber;
            PageSize ??= PaginationSetting.DefaultPageSize;
        }

        /// <summary>
        /// Gets or sets a flag indicating whether to prevent if no entity was found.
        /// </summary>
        public bool PreventIfNoEntityWasFound { get; set; } = false;

        /// <summary>
        /// Gets or sets a flag indicating whether to enable tracking mode.
        /// </summary>
        public bool TrackingMode { get; set; } = false;

        /// <summary>
        /// Gets or sets a flag indicating whether to include even archived data.
        /// </summary>
        public bool EvenArchivedData { get; set; } = false;

        /// <summary>
        /// Gets a value indicating whether to include archived data in the query configuration.
        /// </summary>
        /// <returns>True if even archived data should be included; otherwise, false.</returns>
        public virtual bool OnIncludingArchivedDataConfiguration()
        {
            return EvenArchivedData;
        }

        /// <summary>
        /// Gets the order by expression for the query.
        /// </summary>
        /// <returns>The order by expression for the query.</returns>
        public virtual Expression<Func<TEntity, object>>? OrderBy()
        {
            return null;
        }

        /// <summary>
        /// Gets the order by descending expression for the query.
        /// </summary>
        /// <returns>The order by descending expression for the query.</returns>
        public virtual Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return null;
        }

        /// <summary>
        /// Gets the include expression for the query.
        /// </summary>
        /// <returns>The include expression for the query.</returns>
        public virtual Expression<Func<TEntity, object>>? Include()
        {
            return null;
        }
    }
}
