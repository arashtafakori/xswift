using CoreX.Base;
using System.Linq.Expressions;

namespace CoreX.Domain
{
    public class Invariant<TModel>
    {
        public Expression<Func<TModel, bool>> Condition { get; set; }
        public IIssue Issue { get; set; }

        public Invariant(
            Expression<Func<TModel, bool>> condition,
            IIssue issue)
        {
            Condition = condition;
            Issue = issue;
        }
    }
}
