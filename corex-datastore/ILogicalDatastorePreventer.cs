using CoreX.Base;
using CoreX.Domain;
using System.Linq.Expressions;

namespace CoreX.Datastore
{
    public interface ILogicalDatastorePreventer<TEntity> 
        where TEntity : BaseEntity<TEntity>
    {
        public Task<bool> CheckAsync(Expression<Func<TEntity, bool>> condition);
        public IIssue? GetIssue();
     }
}
