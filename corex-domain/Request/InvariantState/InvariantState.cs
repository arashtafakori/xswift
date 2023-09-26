using CoreX.Base;
using MediatR;
using System.Reflection;

namespace CoreX.Domain
{
    public class InvariantState
    {
        private List<IIssue> Issues { get; set; } = new();

        public InvariantState DefineAnInvariant(
            bool result,
            IIssue issue)
        {
            if (result)
                Issues.Add(issue);

            return this;
        }
        public InvariantState DefineAnInvariant(
            IIssue issue,
            Func<bool> condition)
        {
            if (condition())
                Issues.Add(issue);

            return this;
        }

        public async Task CheckAsync(IMediator mediator)
        {
            if (Issues.Count > 0)
                throw new ErrorException(
                    new Error(
                        service: Assembly.GetEntryAssembly()!.GetName().Name!,
                        errorType: ErrorType.Invariant,
                        issues: Issues));
        }
    }
}
