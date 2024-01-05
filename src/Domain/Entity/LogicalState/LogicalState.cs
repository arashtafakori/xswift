 using XSwift.Base;
using System.Reflection;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a state for managing logical preventers and issues in the domain model.
    /// </summary>
    public class LogicalState
    {
        /// <summary>
        /// The list of issues associated with the logical state.
        /// </summary>
        private readonly List<IIssue> _issues = new();

        /// <summary>
        /// The list of logical preventers to be assessed.
        /// </summary>
        private readonly List<LogicalPreventer> _preventers = new();

        /// <summary>
        /// Gets the list of issues associated with the logical state.
        /// </summary>
        public List<IIssue> GetIssues() => _issues;

        /// <summary>
        /// Gets the list of logical preventers.
        /// </summary>
        public List<LogicalPreventer> GetPreventers() => _preventers;

        /// <summary>
        /// Adds a logical preventer to be assessed.
        /// </summary>
        /// <param name="preventer">The logical preventer to add.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState AddAnPreventer(LogicalPreventer preventer)
        {
            _preventers.Add(preventer);

            return this;
        }

        /// <summary>
        /// Describes a logical preventer based on a specified result and associated issue.
        /// </summary>
        /// <param name="result">The result of the condition.</param>
        /// <param name="issue">The issue associated with the preventer.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState DescribeAPreventer(
            bool result,
            IIssue issue)
        {
            if (result)
                _issues.Add(issue);

            return this;
        }

        /// <summary>
        /// Describes a logical preventer based on a specified condition and associated issue.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="issue">The issue associated with the preventer.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState DescribeAPreventer(
            Func<bool> condition,
            IIssue issue)
        {
            if (condition())
                _issues.Add(issue);

            return this;
        }

        /// <summary>
        /// Adds an issue directly to the logical state.
        /// </summary>
        /// <param name="issue">The issue to add.</param>
        /// <returns>The current instance of the logical state for fluent chaining.</returns>
        public LogicalState AddIssue(IIssue issue)
        {
            _issues.Add(issue);
   
            return this;
        }

        /// <summary>
        /// Asynchronously assesses all registered logical preventers and raises a logical error exception if any issues are detected.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AssesstAsync()
        {
            foreach (var preventer in _preventers)
            {
                if (await preventer.ResolveAsync() && preventer.GetIssue() != null)
                    _issues.Add(preventer.GetIssue()!);
            }

            if (_issues.Count > 0)
                ThrowLogicalErrorException();
        }

        /// <summary>
        /// Throws a logical error exception containing the list of detected issues.
        /// </summary>
        private void ThrowLogicalErrorException()
        {
            throw new ErrorException(
                new Error(
                    service: Assembly.GetEntryAssembly()!.GetName().Name!,
                    errorType: ErrorType.Logical,
                    issues: _issues));
        }
    }
}
