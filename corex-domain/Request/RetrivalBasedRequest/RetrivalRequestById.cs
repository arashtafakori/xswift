using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalRequestById<TEntity, IdType> :
        RetrivalRequest<TEntity> where TEntity : EntityById<TEntity, IdType>
    {
        public IdType Id { get; private set; }
        public RetrivalRequestById(
            IdType id,
            bool trackingMode = false)
            : base(trackingMode: trackingMode)
        {
            Id = id;
        }

        public override Expression<Func<TEntity, bool>>? Condition()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
