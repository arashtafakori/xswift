using MediatR;

namespace XSwift.Domain
{
    public abstract class BulkCommandRequest<TEntity, TReturenedModel>
        : QueryListRequest<TEntity, TReturenedModel>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
    }
}
