using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class LogicalPreventer
    {
        public string Description { get; private set; } = string.Empty;
        public virtual Task<bool> ResolveAsync()
        {
            throw new NotImplementedException();
        }
        public virtual IIssue? GetIssue()
        {
            throw new NotImplementedException();
        }
        public LogicalPreventer WithDescription(string value)
        {
            Description = value;
            return this;
        }
    }
}
