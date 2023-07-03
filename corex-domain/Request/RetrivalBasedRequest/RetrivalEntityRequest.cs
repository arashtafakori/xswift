namespace CoreX.Domain
{
    public abstract class RetrivalEntityRequest<TEntity> :
        RetrivalRequest<TEntity> where TEntity : BaseEntity
    {
        public RetrivalEntityRequest(bool trackingMode = false)
            : base(trackingMode : trackingMode) { }
    }
}
