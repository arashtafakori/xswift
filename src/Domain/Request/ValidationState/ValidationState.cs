using XSwift.Base;
using System.Reflection;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a state for managing validations for a specific request type.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request associated with the validation state.</typeparam>
    public class ValidationState<TRequest>
        where TRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the request associated with the validation state.
        /// </summary>
        private TRequest Request { get; set; }

        /// <summary>
        /// The list of validation issues.
        /// </summary>
        private readonly List<IIssue> _issues = new();

        /// <summary>
        /// The list of validations.
        /// </summary>
        private readonly List<Validation> _validations = new();

        /// <summary>
        /// Gets the list of validation issues.
        /// </summary>
        public List<IIssue> GetIssues() => _issues;

        /// <summary>
        /// Gets the list of validations.
        /// </summary>
        public List<Validation> GetValidations() => _validations;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationState{TRequest}"/> class.
        /// </summary>
        /// <param name="request">The request associated with the validation state.</param>
        public ValidationState(TRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Adds a validation to be applied during the validation process.
        /// </summary>
        /// <param name="validation">The validation to add.</param>
        /// <returns>The current instance of the validation state for fluent chaining.</returns>
        public ValidationState<TRequest> AddAValidation(Validation validation)
        {
            _validations.Add(validation);

            return this;
        }

        /// <summary>
        /// Defines a validation based on a specified result and associated issue.
        /// </summary>
        /// <param name="result">The result of the condition.</param>
        /// <param name="issue">The issue associated with the validation.</param>
        /// <returns>The current instance of the validation state for fluent chaining.</returns>
        public ValidationState<TRequest> DefineAValidation(
            bool result,
            IIssue issue)
        {
            if (result)
                _issues.Add(issue);

            return this;
        }

        /// <summary>
        /// Defines a validation based on a specified condition and associated issue.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="issue">The issue associated with the validation.</param>
        /// <returns>The current instance of the validation state for fluent chaining.</returns>
        public ValidationState<TRequest> DefineAValidation(
            Func<bool> condition,
            IIssue issue)
        {
            if (condition())
                _issues.Add(issue);

            return this;
        }

        /// <summary>
        /// Validates the request by applying all registered validations and checking for attribute-based validations.
        /// </summary>
        public void Validate()
        {
            foreach (var validation in _validations)
            {
                if (validation.Resolve())
                    if (validation.GetIssue() != null)
                        _issues.Add(validation.GetIssue()!);
            }

            ValidateValiationAttributes();
            ValidateBindedValiationAttributes();

            if (_issues.Count > 0)
                ThrowErrorException();
        }

        /// <summary>
        /// Validates a property based on attribute-based validations.
        /// </summary>
        /// <param name="property">The property to validate.</param>
        /// <param name="value">The value of the property.</param>
        /// <param name="fieldName">The name of the field associated with the property.</param>
        internal void ValidateProperty(
            PropertyInfo property,
            object? value,
            string fieldName)
        {
            //var attributes = property.GetCustomAttributes();
            var attributes = property.GetCustomAttributes().OfType<FieldValidationAttribute>();

            foreach (var attribute in attributes)
                attribute.Validate(value, _issues, fieldName);
        }

        /// <summary>
        /// Validates properties based on attribute-based validations.
        /// </summary>
        internal void ValidateValiationAttributes()
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

        /// <summary>
        /// Validates properties based on attributes that specify bindings to other properties.
        /// </summary>
        internal void ValidateBindedValiationAttributes()
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

        /// <summary>
        /// Throws an error exception containing the list of detected validation issues.
        /// </summary>
        private void ThrowErrorException()
        {
            throw new ErrorException(
                new Error(
                    service: Assembly.GetEntryAssembly()!.GetName().Name!,
                    errorType: ErrorType.Validation,
                    issues: _issues));
        }
    }
}