namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntityRequest<TEntity> :
        RetrivalEntityRequest<TEntity> where TEntity : BaseEntity
    {
        public ReadonlyRetrivalEntityRequest(bool evenArchivedData = false)
            : base(trackingMode: false, evenArchivedData: evenArchivedData)
        {
        }
    }
}
