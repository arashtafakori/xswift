using System.Linq.Expressions;
using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class InvariantRequest<TEntity>
        : AnyRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public string Description { get; private set; } = string.Empty;

        public virtual IIssue? GetIssue()
        {
            throw new NotImplementedException();
        }
        public InvariantRequest<TEntity> WithDescription(string value)
        {
            Description = value;
            return this;
        }
    }
}
