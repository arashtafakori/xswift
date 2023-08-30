using CoreX.Base;
using MediatR;
using System.Collections;
using System.Reflection;

namespace CoreX.Domain
{
    public class InvariantState :
        IEnumerable<IInvariant>
    {
        private List<IIssue> Issues { get; set; } = new();
        private readonly List<IInvariant> _invariants = new();
        public InvariantState Add(IInvariant invariant)
        {
            _invariants.Add(invariant);
            return this;
        }

        public InvariantState DescribeAnInvariant(
            IIssue issue,
            Func<bool> condition)
        {
            if (condition())
                Issues.Add(issue);

            return this;
        }
        public InvariantState AddIssue(IIssue issue)
        {
            Issues.Add(issue);
            return this;
        }
        public IEnumerator<IInvariant> GetEnumerator()
        {
            return new InvariantEnumerator(_invariants);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public async Task CheckAsync(IMediator mediator)
        {
            foreach (var invariant in _invariants)
            {
                if (await invariant.CheckAsync(mediator))
                    if (invariant.GetIssue() != null)
                        Issues.Add(invariant.GetIssue()!);
            }

            if (Issues.Count > 0)
                throw new ErrorException(
                    new Error(
                        service: Assembly.GetEntryAssembly()!.GetName().Name!,
                        errorType: ErrorType.Invariant,
                        issues: Issues));
        }

        private class InvariantEnumerator : IEnumerator<IInvariant>
        {
            private List<IInvariant> _invariants;
            private int currentIndex = -1;

            public InvariantEnumerator(List<IInvariant> invariants)
            {
                _invariants = invariants;
            }

            IInvariant Current => _invariants[currentIndex];

            object IEnumerator.Current => Current;

            IInvariant IEnumerator<IInvariant>.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _invariants.Count;
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
