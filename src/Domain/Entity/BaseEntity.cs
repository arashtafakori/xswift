using XSwift.Base;

namespace XSwift.Domain
{
    public abstract class BaseEntity<TEntity> : ISoftDelete
    {
        public byte Deleted { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual void Create()
        {
            CreatedDate = ModifiedDate = DateTimeHelper.UtcNow;
        }
        public virtual void Update()
        {
            ModifiedDate = DateTimeHelper.UtcNow;
        }
        public virtual void Archive()
        {
            ModifiedDate = DateTimeHelper.UtcNow;
        }
        public virtual void Restore()
        {
            ModifiedDate = DateTimeHelper.UtcNow;
        }
        public virtual void Delete()
        {
        }

        public virtual ConditionProperty<TEntity>? Uniqueness() { return null; }
    }
}
