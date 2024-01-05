using XSwift.Base;
using System.Linq.Expressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents an invariant constraint for a specified model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model to which the invariant applies.</typeparam>
    public class Invariant<TModel>
    {
        /// <summary>
        /// Gets or sets the condition expressed as a lambda expression that defines the invariant constraint.
        /// </summary>
        public Expression<Func<TModel, bool>> Condition { get; set; }

        /// <summary>
        /// Gets or sets the issue associated with the invariant constraint.
        /// </summary>
        public IIssue Issue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invariant{TModel}"/> class with the specified condition and issue.
        /// </summary>
        /// <param name="condition">The condition expressed as a lambda expression that defines the invariant constraint.</param>
        /// <param name="issue">The issue associated with the invariant constraint.</param>
        public Invariant(
            Expression<Func<TModel, bool>> condition,
            IIssue issue)
        {
            Condition = condition;
            Issue = issue;
        }
    }
}
