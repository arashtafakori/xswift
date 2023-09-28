using System.Linq.Expressions;

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
