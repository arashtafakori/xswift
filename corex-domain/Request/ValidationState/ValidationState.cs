using CoreX.Base;
using System.Reflection;

namespace CoreX.Domain
{
    public class ValidationState<TRequest>
        where TRequest : BaseRequest
    {
        private TRequest Request { get; set; }
        private List<IIssue> Issues { get; set; } = new();
        private readonly List<Validation> _validations = new();

        public ValidationState(TRequest request)
        {
            Request = request;
        }

        public ValidationState<TRequest> AddAnValidation(Validation validation)
        {
            _validations.Add(validation);
            return this;
        }
        public ValidationState<TRequest> DefineAValidation(
            bool result,
            IIssue issue)
        {
            if (result)
                Issues.Add(issue);

            return this;
        }
        public ValidationState<TRequest> DefineAValidation(
            Func<bool> condition,
            IIssue issue)
        {
            if (condition())
                Issues.Add(issue);

            return this;
        }

        public void Validate()
        {
            foreach (var validation in _validations)
            {
                if (validation.Resolve())
                    if (validation.GetIssue() != null)
                        Issues.Add(validation.GetIssue()!);
            }

            ValidateValiationAttributes();
            ValidateBindedValiationAttributes();

            if (Issues.Count > 0) 
                throw new ErrorException(
                    new Error(
                        service: Assembly.GetEntryAssembly()!.GetName().Name!,
                        errorType: ErrorType.Validation,
                        issues: Issues));
        }

        private void ValidateValiationAttributes()
        {
            var sourceProperties = Request.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                ValidateProperty(
                    sourceProperty,
                    sourceProperty.GetValue(Request),
                    sourceProperty.Name);
            }
        }
        private void ValidateBindedValiationAttributes()
        {
            var sourceProperties = Request.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var attribute = (BindToAttribute)Attribute.
                    GetCustomAttribute(sourceProperty, typeof(BindToAttribute))!;

                if (attribute != null)
                {
                    var targetType = attribute.TargetType;
                    var targetPropertyName = attribute.TargetPropertyName;

                    var targetProperty = targetType.GetProperty(targetPropertyName);

                    if (targetProperty != null)
                    {
                        ValidateProperty(
                            targetProperty,
                            sourceProperty.GetValue(Request), 
                            sourceProperty.Name);
                    }
                }
            }
        }
        private void ValidateProperty(
            PropertyInfo property,
            object? value,
            string fieldName)
        {
            var attributes = property.GetCustomAttributes();

            foreach (var attribute in attributes)
            {
                if (attribute is FieldValidationAttribute)
                    ((FieldValidationAttribute)attribute).Validate(
                                             value, Issues, fieldName);
            }
        }
    }
}