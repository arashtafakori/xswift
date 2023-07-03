using CoreX.Base;
using System.ComponentModel.DataAnnotations;

namespace CoreX.Domain
{
    public abstract class BaseEntity : ISoftDelete
    {
        [Required]
        public byte Deleted { get; set; } = 0;

        [Required]
        public DateTime? ModifiedDate { get; set; }

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
