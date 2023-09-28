using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class RequestToRestoreById<TEntity, IdType> :
        RequestToRestore<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public RequestToRestoreById(IdType id)
        {
            Id = id;
        }

        public IdType Id { get; private set; }
        public virtual void SetId(IdType value)
        {
            Id = value;
        }
        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
