using System.ComponentModel.DataAnnotations;

namespace Artaco.Infrastructure.CoreX
{
    public abstract class BaseEntity : ISoftDelete
    {
        [Required]
        public byte Deleted { get; set; } = 0;

        [Required]
        public DateTime? ModifiedDate { get; set; }
        public void Creation()
        {
            ModifiedDate = DateTimeUtils.Now;
        }
        public void Updation()
        {
            ModifiedDate = DateTimeUtils.Now;
        }
        public void Deletion()
        {
            ModifiedDate = DateTimeUtils.Now;
        }
        public void UnDeletion()
        {
            ModifiedDate = DateTimeUtils.Now;
        }
        public void HardDeletion()
        {
        }
        public void Validate()
        {
            new EntityValidator().Validate(this);
        }
    }
}
