using System.Linq.Expressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a condition property used for specifying criteria for entity uniqueness.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ConditionProperty<TEntity>
    {
        /// <summary>
        /// Gets or sets the expression representing the condition for uniqueness.
        /// </summary>
        public Expression<Func<TEntity, bool>>? Condition { get; set; }

        /// <summary>
        /// Gets or sets a description of the condition property.
        /// </summary>
        public string? Description { get; set; }
    }
}
