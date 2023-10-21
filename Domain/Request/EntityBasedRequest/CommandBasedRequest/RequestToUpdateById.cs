using System.Linq.Expressions;
using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class RequestToUpdateById<TEntity, IdType> :
        RequestToUpdate<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public RequestToUpdateById(IdType id)
        {
            Id = id;
        }

        public IdType Id { get; private set; }

        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        public virtual RequestToUpdateById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
