using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for bulk command requests associated with a specific entity type,
    /// The bulk command is not common and it is more likely to be used in some rare cases.
    /// Using the buck command is a violation of DDD concepts. Do not use this item as much as you can. 
    /// Try to design the domain correctly.
    /// returning a specified result model.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the bulk command request.</typeparam>
    /// <typeparam name="TReturnedModel">The type of the result model returned by the bulk command request.</typeparam>
    public abstract class BulkCommandRequest<TEntity, TReturenedModel>
        : QueryListRequest<TEntity, TReturenedModel>, IRequest
        where TEntity : BaseEntity<TEntity>
    {
        // This class inherits from QueryListRequest<TEntity, TReturnedModel> and IRequest,
        // providing the base functionality for a bulk command request.

        // Additional members or specific logic for bulk command requests can be added as needed.
    }
}
