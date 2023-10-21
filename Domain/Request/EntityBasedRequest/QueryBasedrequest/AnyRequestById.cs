using XSwift.Base;

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
        public override ExpressionBuilder<TEntity> Where()
        {
            WhereExpression.And(x => x.Id!.Equals(Id));
            return base.Where();
        }

        public virtual AnyRequestById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
