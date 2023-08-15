using CoreX.Base;

namespace CoreX.Domain
{
    public abstract class BaseEntity : ISoftDelete
    {
        public byte Deleted { get; set; } = 0;

        public DateTime ModifiedDate { get; set; }

        public virtual void Creation()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void Updation()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void Deletion()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void UnDeletion()
        {
            ModifiedDate = DateTimeHelper.Now;
        }
        public virtual void HardDeletion()
        {
        }
    }
}
