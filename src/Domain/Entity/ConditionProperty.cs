using System.Linq.Expressions;

namespace XSwift.Domain
{
    public class ConditionProperty<TEntity>
    {
        public Expression<Func<TEntity, bool>>? Condition { get; set; }
        public string? Description { get; set; }
    }
}
