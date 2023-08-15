namespace CoreX.Domain
{
    public abstract class ReadonlyRetrivalEntityRequestById<TEntity, IdType>
        : RetrivalEntityRequestById<TEntity, IdType>
        where TEntity : Entity<TEntity, IdType>
    {
        public ReadonlyRetrivalEntityRequestById(IdType id, bool evenArchivedData = false) :
            base(id, trackingMode: false, evenArchivedData: evenArchivedData)
        {
        }
    }
}
