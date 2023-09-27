using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class AnyRequestById<TEntity, IdType> :
        AnyRequest<TEntity> 
        where TEntity : Entity<TEntity, IdType>
    {
        public AnyRequestById(
            IdType id)
        {
            Id = id;
        }
 
        public IdType Id { get; private set; }
        public void SetId(IdType value)
        {
            Id = value;
        }
        public override Expression<Func<TEntity, bool>>? Condition()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
