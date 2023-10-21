using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class QueryItemRequestById<TEntity, IdType, TReturnedType>
        : QueryItemRequest<TEntity, TReturnedType>
        where TEntity : Entity<TEntity, IdType>
    {
        public IdType Id { get; private set; }
        public QueryItemRequestById(
            IdType id)
        {
            Id = id; 
        }

        public override ExpressionBuilder<TEntity> Where()
        {
            WhereExpression.And(x => x.Id!.Equals(Id));
            return base.Where();
        }

        public virtual QueryItemRequestById<TEntity, IdType, TReturnedType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
