using XSwift.Base;
using XSwift.Domain;
using System.Linq.Expressions;

namespace XSwift.Datastore
{
    /// <summary>
    /// Interface for preventing logical data store operations on a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to be prevented.</typeparam>
    public interface ILogicalDatastorePreventer<TEntity> 
        where TEntity : BaseEntity<TEntity>
    {
        /// <summary>
        /// Asynchronously checks a specified condition before allowing logical data store operations.
        /// </summary>
        /// <param name="condition">The condition to be checked.</param>
        /// <returns>A task representing the asynchronous operation, returning a boolean indicating whether the operation is allowed.</returns>
        public Task<bool> CheckAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Gets the issue associated with the prevention.
        /// </summary>
        /// <returns>The issue associated with the prevention, or null if no issue is present.</returns>
        public IIssue? GetIssue();
     }
}
