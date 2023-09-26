using CoreX.Base;

namespace CoreX.Domain
{
    public abstract class Validation
    {
        public string Description { get; private set; } = string.Empty;
        public virtual bool Resolve()
        {
            throw new NotImplementedException();
        }
        public virtual IIssue? GetIssue()
        {
            throw new NotImplementedException();
        }
        public Validation WithDescription(string value)
        {
            Description = value;
            return this;
        }
    }
}
