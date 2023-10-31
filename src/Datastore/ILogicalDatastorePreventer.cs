using XSwift.Base;
using XSwift.Domain;
using System.Linq.Expressions;

namespace XSwift.Datastore
{
    public interface ILogicalDatastorePreventer<TEntity> 
        where TEntity : BaseEntity<TEntity>
    {
        public Task<bool> CheckAsync(Expression<Func<TEntity, bool>> condition);
        public IIssue? GetIssue();
     }
}
