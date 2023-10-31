using Newtonsoft.Json;
using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class EntityBasedRequest<TEntity> :
        BaseRequest
        where TEntity : BaseEntity<TEntity>
    {
        [JsonIgnore]
        public ExpressionBuilder<TEntity> WhereExpression { get; private set; } = new ExpressionBuilder<TEntity>();

        public EntityBasedRequest()
        {
            InvariantState = new();
        }
        [JsonIgnore]
        public InvariantState<TEntity> InvariantState { get; private set; }

        public virtual ExpressionBuilder<TEntity> Where()
        {
            return WhereExpression;
        }
    }
}
