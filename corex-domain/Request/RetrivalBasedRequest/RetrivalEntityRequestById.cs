using System.Linq.Expressions;

namespace CoreX.Domain
{
    public abstract class RetrivalEntityRequestById<TEntity, IdType>
        : RetrivalRequestById<TEntity, IdType>
        where TEntity : Entity<TEntity, IdType>
    {
        public RetrivalEntityRequestById(IdType id, 
            bool trackingMode = false) :
            base(id, trackingMode)
        {
        }
    }
}
