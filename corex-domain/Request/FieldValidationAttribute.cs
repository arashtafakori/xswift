using CoreX.Base;
using CoreX.Domain.Properties;

namespace CoreX.Domain
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public abstract class FieldValidationAttribute : Attribute
    {
        private string _errorMessage;

        public FieldValidationAttribute()
            : this(Resource.Validation_ValidationError)
        {
        }

        protected FieldValidationAttribute(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public string? ErrorMessage
        {
            get => _errorMessage;
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
