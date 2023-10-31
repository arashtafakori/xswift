using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class InvariantRequestById<TEntity, IdType> :
        InvariantRequest<TEntity> 
        where TEntity : Entity<TEntity, IdType>
    {
        public InvariantRequestById(
            IdType id)
        {
            Id = id;
        }
 
        public IdType Id { get; private set; }

        public override ExpressionBuilder<TEntity> Where()
        {
            WhereExpression.And(x => x.Id!.Equals(Id));
            return base.Where();
        }

        public virtual InvariantRequestById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
