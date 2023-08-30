using CoreX.Base;

namespace CoreX.Domain
{
    public abstract class BaseEntity : ISoftDelete
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
    }
}
