using XSwift.Base;
using System.Reflection;
using MediatR;

namespace XSwift.Domain
{
    public class InvariantState<TEntity> where TEntity : BaseEntity<TEntity>
    {
        private List<IIssue> Issues { get; set; } = new();
        private readonly List<InvariantRequest<TEntity>> _invariantRequests = new List<InvariantRequest<TEntity>>();
        public InvariantState<TEntity> AddAnInvariantRequest(InvariantRequest<TEntity> request)
        {
            _invariantRequests.Add(request);
            return this;
        }
        public InvariantState<TEntity> DefineAnInvariant(
            bool result, IIssue issue)
        {
            if (result)
                Issues.Add(issue);

            return this;
        }
        public InvariantState<TEntity> DefineAnInvariant(
            IIssue issue, Func<bool> condition)
        {
            if (condition())
                Issues.Add(issue);

            return this;
        }

        public async Task AssestAsync(IMediator mediator)
        {
            foreach (var request in _invariantRequests)
            {
                if ((bool)(await mediator.Send(request))!)
                    if (request.GetIssue() != null)
                        Issues.Add(request.GetIssue()!);
            }

            if (Issues.Count > 0)
                throw new ErrorException(
                    new Error(
                        service: Assembly.GetEntryAssembly()!.GetName().Name!,
                        errorType: ErrorType.Invariant,
                        issues: Issues));
        }
    }
}
