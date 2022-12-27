using System.ComponentModel.DataAnnotations;

namespace CoreX.Structure
{
    public abstract class Entity : IEntity, ICascadeSoftDelete
    {
        [Required]
        public byte SoftDeleteLevel { get; set; } = 0;

        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? DeletationDate { get; set; }
        public DateTime? UpdationDate { get; set; }

        public override void Creation()
        {
            CreationDate = DateTimeUtils.Now;
        }
        public override void Updation()
        {
            UpdationDate = DateTimeUtils.Now;
        }
        public override void Deletion()
        {
        }
        public override void UnDeletion()
        {
        }
        public override void Validate()
        {
            new EntityValidator().Validate(this);
        }
    }
}
