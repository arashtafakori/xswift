namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntitiesRequest<TEntity> :
        RetrivalEntitiesRequest<TEntity> where TEntity : BaseEntity
    {
        public ReadonlyRetrivalEntitiesRequest()
            : base(trackingMode: false)
        {
        }
    }
}
