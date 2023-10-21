using System.Linq.Expressions;
using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class RequestToArchiveById<TEntity, IdType> :
        RequestToArchive<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public RequestToArchiveById(IdType id)
        {
            Id = id;
        }

        public IdType Id { get; private set; }

        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }
        public virtual RequestToArchiveById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
