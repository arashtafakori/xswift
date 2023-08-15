using CoreX.Base;
using System.Reflection;

namespace CoreX.Domain
{
    public class LogicalState :
        IEnumerable<IIssue>
    {
        private readonly List<IIssue> _issues = new();
        public LogicalState Add(IIssue issue)
        {
            _issues.Add(issue);
            return this;
        }
        public IEnumerator<IIssue> GetEnumerator()
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

        private class LogicalIssueEnumerator : IEnumerator<IIssue>
        {
            private List<IIssue> _issues;
            private int currentIndex = -1;

            public LogicalIssueEnumerator(List<IIssue> issues)
            {
                _issues = issues;
            }

            IIssue Current => _issues[currentIndex];

            IIssue IEnumerator<IIssue>.Current => Current;

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
