namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntitiesRequest<TEntity> :
        RetrivalEntitiesRequest<TEntity> where TEntity : BaseEntity
    {
        public ReadonlyRetrivalEntitiesRequest(bool evenArchivedData = false)
            : base(trackingMode: false, evenArchivedData: evenArchivedData)
        {
        }
    }
}
