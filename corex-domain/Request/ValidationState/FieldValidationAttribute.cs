using CoreX.Base;
using CoreX.Domain.Properties;

namespace CoreX.Domain
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public abstract class FieldValidationAttribute : Attribute
    {
        private string _description;

        public FieldValidationAttribute()
            : this(string.Empty)
        {
        }

        protected FieldValidationAttribute(string description)
        {
            _description = description;
        }

        public string? Description
        {
            get => _description;
        }

        public virtual bool IsValid(object? value)
        {
            throw new NotImplementedException();
        }
        public virtual void Validate(
            object? value,
            ICollection<IIssue> _issues,
            string propertyName = "")
        {
            throw new NotImplementedException();
        }
    }
}
