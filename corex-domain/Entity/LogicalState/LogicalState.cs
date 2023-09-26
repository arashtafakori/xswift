using CoreX.Base;
using System.Reflection;

namespace CoreX.Domain
{
    public class LogicalState
    {
        private List<IIssue> Issues { get; set; } = new();
        private readonly List<LogicalPreventer> _preventers = new();
        public LogicalState AddAnPreventer(LogicalPreventer preventer)
        {
            _preventers.Add(preventer);
            return this;
        }
        public LogicalState DescribeAPreventer(
            bool result,
            IIssue issue)
        {
            if (result)
                Issues.Add(issue);

            return this;
        }
        public LogicalState DescribeAPreventer(
            Func<bool> condition,
            IIssue issue)
        {
            if (condition())
                Issues.Add(issue);

            return this;
        }
        public LogicalState AddIssue(IIssue issue)
        {
            Issues.Add(issue);
            return this;
        }
        public async Task CheckAsync()
        {
            foreach (var preventer in _preventers)
            {
                if (await preventer.ResolveAsync())
                    if (preventer.GetIssue() != null)
                        Issues.Add(preventer.GetIssue()!);
            }

            if (Issues.Count > 0)
                throw new ErrorException(
                    new Error(
                        service: Assembly.GetEntryAssembly()!.GetName().Name!,
                        errorType: ErrorType.Logical,
                        issues: Issues));
        }
    }
}
