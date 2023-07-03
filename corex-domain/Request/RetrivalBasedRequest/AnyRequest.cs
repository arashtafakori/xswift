namespace CoreX.Domain
{
    public abstract class AnyRequest<TEntity> :
        ReadonlyRetrivalEntityRequest<TEntity> 
        where TEntity : BaseEntity
    {
    }
}
