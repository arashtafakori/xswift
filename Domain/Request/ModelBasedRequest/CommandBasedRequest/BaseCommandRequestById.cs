using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class BaseCommandRequestById<TEntity, IdType> :
        BaseCommandRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public BaseCommandRequestById(IdType id) {
            Id = id;
        }

        public IdType Id { get; private set; }
        public virtual void SetId(IdType value)
        {
            Id = value;
        }
        public override Expression<Func<TEntity, bool>>? Condition()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
