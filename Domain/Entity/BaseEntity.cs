using XSwift.Base;
using System.Linq.Expressions;

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

        private Expression<Func<TEntity, bool>>? _conditionOfBeingUnique;

        public void SetConditionOfBeingUnique(
            Expression<Func<TEntity, bool>>? condition,
            string? description = null)
        {
            _conditionOfBeingUnique = condition;
            _descriptionOfConditionOfBeingUnique = description;
        }
        public Expression<Func<TEntity, bool>>? GetConditionOfBeingUnique()
        {
            return _conditionOfBeingUnique;
        }

        private string? _descriptionOfConditionOfBeingUnique;

        public string? GetDescriptionOfConditionOfBeingUnique()
        {
           return _descriptionOfConditionOfBeingUnique ;
        }
    }
}
