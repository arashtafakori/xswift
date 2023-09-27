using MediatR;

namespace XSwift.Domain
{
    public abstract class QueryItemRequest<TEntity>
        : QueryRequest<TEntity> 
        where TEntity : BaseEntity<TEntity>
    {
    }
}
