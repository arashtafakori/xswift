using System.Linq.Expressions;
using XSwift.Base;

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

        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        public virtual RequestToRestoreById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
