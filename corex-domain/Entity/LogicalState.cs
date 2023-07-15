using CoreX.Base;
using System.Reflection;

namespace CoreX.Domain
{
    public class LogicalState :
        IEnumerable<Issue>
    {
        private readonly List<Issue> _issues = new();
        public void Add(Issue issue)
        {
            _issues.Add(issue);
        }
        public IEnumerator<Issue> GetEnumerator()
        {
            return new LogicalIssueEnumerator(_issues);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Throw()
        {
            if (_issues.Count > 0)
                throw new ErrorException(
                    new Error(
                        service: Assembly.GetEntryAssembly()!.GetName().Name!,
                        errorType: ErrorType.Logical,
                        issues: _issues));
        }

        private class LogicalIssueEnumerator : IEnumerator<Issue>
        {
            private List<Issue> _issues;
            private int currentIndex = -1;

            public LogicalIssueEnumerator(List<Issue> issues)
            {
                _issues = issues;
            }

            Issue Current => _issues[currentIndex];

            Issue IEnumerator<Issue>.Current => Current;

            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _issues.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
