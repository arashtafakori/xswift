using XSwift.Base;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    public abstract class ModelBasedRequest<TModel> :
        BaseRequest
    {
        public virtual Expression<Func<TModel, bool>>? Condition()
        {
            return null;
        }

        private readonly List<Invariant<TModel>> _invariants = new();
        public ModelBasedRequest<TModel> DefineAPersistentBasedInvariant(
            Expression<Func<TModel, bool>> condition,
            IIssue issue)
        {
            _invariants.Add(new Invariant<TModel>(
                    condition: condition,
                    issue: issue));
            return this;
        }

        public List<Invariant<TModel>> GetInvariants()
        {
            return _invariants;
        }
    }
}
