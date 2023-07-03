using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class AnyRequestById<TEntity, IdType> :
        AnyRequest<TEntity>
        where TEntity : EntityById<TEntity, IdType>
    {
        public IdType Id { get; private set; }
        public AnyRequestById(IdType id)
        {
            Id = id;
        }

        public override Expression<Func<TEntity, bool>>? Condition()
        {
            return x => x.Id!.Equals(Id);
        }
    }
}
