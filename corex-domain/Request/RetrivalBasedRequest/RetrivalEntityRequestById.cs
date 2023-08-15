using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalEntityRequestById<TEntity, IdType>
        : RetrivalEntityRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public IdType Id { get; private set; }
        public RetrivalEntityRequestById(
            IdType id, 
            bool trackingMode = false,
            bool evenArchivedData = false) :
            base(
                trackingMode: trackingMode,
                evenArchivedData: evenArchivedData)
        {
            Id = id;
        }

        public override Expression<Func<TEntity, bool>>? Condition()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
