namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntitiesRequest<TEntity> :
        RetrivalEntitiesRequest<TEntity> where TEntity : BaseEntity
    {
        public ReadonlyRetrivalEntitiesRequest(
            bool evenArchivedData = false,
            int offset = 0,
            int limit = 0)
            : base(
                  trackingMode: false,
                  evenArchivedData: evenArchivedData,
                  offset: offset,
                  limit: limit)
        {
        }
    }
}
