namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntityRequestById<TEntity, IdType>
        : RetrivalRequestById<TEntity, IdType>
        where TEntity : EntityById<TEntity, IdType>
    {
        public ReadonlyRetrivalEntityRequestById(IdType id,
            bool trackingMode = false) :
            base(id, trackingMode)
        {
        }
    }
}
