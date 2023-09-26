using MediatR;

namespace CoreX.Domain
{
    public abstract class QueryItemRequest<TEntity>
        : QueryRequest<TEntity> 
        where TEntity : BaseEntity<TEntity>
    {
    }
}
