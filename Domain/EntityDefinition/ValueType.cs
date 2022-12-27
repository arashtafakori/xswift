using System.ComponentModel.DataAnnotations;

namespace CoreX.Structure
{
    public abstract class ValueType : IEntity
    {
        [Required]
        public DateTime CreationDate { get; set; }

        public override void Creation()
        {
            CreationDate = DateTimeUtils.Now;
        }

        public override void Validate()
        {
            new EntityValidator().Validate(this);
        }
    }
}
