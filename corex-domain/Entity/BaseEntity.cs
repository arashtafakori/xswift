using CoreX.Base;

namespace CoreX.Domain
{
    public abstract class BaseEntity : ISoftDelete
    {
        public byte Deleted { get; set; } = 0;

        public DateTime ModifiedDate { get; set; }

        public virtual void Create()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void Update()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void Archive()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void Restore()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void Delete()
        {
        }
    }
}
