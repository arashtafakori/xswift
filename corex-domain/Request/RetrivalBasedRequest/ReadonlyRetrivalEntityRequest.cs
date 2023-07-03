namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntityRequest<TEntity> :
        RetrivalEntityRequest<TEntity> where TEntity : BaseEntity
    {
        public ReadonlyRetrivalEntityRequest()
            : base(trackingMode: false)
        {
        }
    }
}
