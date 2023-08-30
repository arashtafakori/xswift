using CoreX.Base;
using System.Collections;
using System.Reflection;

namespace CoreX.Domain
{
    public class ValidationState<TRequest> : IEnumerable<IValidation>
        where TRequest : Request
    {
        private TRequest Request { get; set; }
        private List<IIssue> Issues { get; set; } = new();
        private readonly List<IValidation> _validations = new();

        public ValidationState(TRequest request)
        {
            Request = request;
        }

        public ValidationState<TRequest> Add(IValidation validation)
        {
            _validations.Add(validation);
            return this;
        }
        public ValidationState<TRequest> DescribeAValidation(
            IIssue issue,
            Func<bool> condition)
        {
            if (condition())
                Issues.Add(issue);

            return this;
        }
        public ValidationState<TRequest> AddIssue(IIssue issue)
        {
            Issues.Add(issue);
            return this;
        }
        public IEnumerator<IValidation> GetEnumerator()
        {
            return new ValidationEnumerator(_validations);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Validate()
        {
            foreach (var validation in _validations)
            {
                if (validation.Check())
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

        private class ValidationEnumerator : IEnumerator<IValidation>
        {
            private List<IValidation> _validations;
            private int currentIndex = -1;

            public ValidationEnumerator(List<IValidation> invariants)
            {
                _validations = invariants;
            }

            IValidation Current => _validations[currentIndex];

            IValidation IEnumerator<IValidation>.Current => Current;

            object System.Collections.IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _validations.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}