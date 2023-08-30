using MediatR;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalEntitiesRequest<TEntity> :
        RetrivalRequest<TEntity> where TEntity : BaseEntity
    {
        public int Offset { get; private set; }
        public int Limit { get; private set; }

        /// <summary>
        /// If the limit parameter is zero, 
        /// it means that there is not any pagination
        /// </summary>
        /// <param name="trackingMode"></param>
        /// <param name="evenArchivedData"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        public RetrivalEntitiesRequest(
            bool trackingMode = false,
            bool evenArchivedData = false,
            int offset = 0,
            int limit = 0)
            : base(trackingMode: trackingMode,
                  evenArchivedData: evenArchivedData)
        {
            Offset = offset;
            Limit = limit;
        }

        public virtual Expression<Func<TEntity, object>>? OrderBy()
        {
            return x => x.CreatedDate;
        }
        public virtual Expression<Func<TEntity, object>>? OrderByDescending()
        {
            return x => x.CreatedDate;
        }

        public virtual void Resolve(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public virtual Task ResolveAsync(List<TEntity> entities, IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
