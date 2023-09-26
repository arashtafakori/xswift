using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class QueryItemRequestById<TEntity, IdType>
        : QueryItemRequest<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public IdType Id { get; private set; }
        public QueryItemRequestById(
            IdType id)
        {
            Id = id;
        }
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
