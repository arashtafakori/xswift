using CoreX.Base;

namespace CoreX.Domain
{
    public interface IValidation
    {
        public bool Check();
        public IIssue? GetIssue();
     }
}
