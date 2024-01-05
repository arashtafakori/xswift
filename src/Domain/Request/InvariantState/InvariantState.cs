using XSwift.Base;
using System.Reflection;
using MediatR;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a state for managing invariant requests and issues for a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the invariant state.</typeparam>
    public class InvariantState<TEntity> where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// The list of issues associated with the invariant state.
        /// </summary>
        private readonly List<IIssue> _issues = new();

        /// <summary>
        /// The list of invariant requests to be assessed.
        /// </summary>
        private readonly List<InvariantRequest<TEntity>> _invariantRequests = new();

        /// <summary>
        /// Gets the list of issues associated with the invariant state.
        /// </summary>
        public List<IIssue> GetIssues() => _issues;

        /// <summary>
        /// Gets the list of invariant requests.
        /// </summary>
        public List<InvariantRequest<TEntity>> GetPreventers() => _invariantRequests;

        /// <summary>
        /// Adds an invariant request to be assessed.
        /// </summary>
        /// <param name="request">The invariant request to add.</param>
        /// <returns>The current instance of the invariant state for fluent chaining.</returns>
        public InvariantState<TEntity> AddAnInvariantRequest(InvariantRequest<TEntity> request)
        {
            _invariantRequests.Add(request);

            return this;
        }

        /// <summary>
        /// Defines an invariant based on a specified result and associated issue.
        /// </summary>
        /// <param name="result">The result of the condition.</param>
        /// <param name="issue">The issue associated with the invariant.</param>
        /// <returns>The current instance of the invariant state for fluent chaining.</returns>
        public InvariantState<TEntity> DefineAnInvariant(
            bool result, IIssue issue)
        {
            if (result)
                _issues.Add(issue);

            return this;
        }

        /// <summary>
        /// Defines an invariant based on a specified issue and condition.
        /// </summary>
        /// <param name="issue">The issue associated with the invariant.</param>
        /// <param name="condition">The condition to evaluate.</param>
        /// <returns>The current instance of the invariant state for fluent chaining.</returns>
        public InvariantState<TEntity> DefineAnInvariant(
            IIssue issue, Func<bool> condition)
        {
            if (condition())
                _issues.Add(issue);

            return this;
        }

        /// <summary>
        /// Asynchronously assesses all registered invariant requests and raises an error exception if any issues are detected.
        /// </summary>
        /// <param name="mediator">The mediator used to send invariant requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AssestAsync(IMediator mediator)
        {
            foreach (var request in _invariantRequests)
            {
                if ((bool)(await mediator.Send(request))!)
                    if (request.GetIssue() != null)
                        _issues.Add(request.GetIssue()!);
            }

            if (_issues.Count > 0)
                ThrowErrorException();
        }

        /// <summary>
        /// Throws an error exception containing the list of detected invariant issues.
        /// </summary>
        private void ThrowErrorException()
        {
            throw new ErrorException(
                new Error(
                    service: Assembly.GetEntryAssembly()!.GetName().Name!,
                    errorType: ErrorType.Invariant,
                    issues: _issues));
        }
    }
}
