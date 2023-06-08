using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CoreX.Domain
{
    public class ValidationContext<TRequest> : 
        IEnumerable<IValidation> 
        where TRequest : LogicalRequest
    {
        private TRequest Request { get; set; }
        public List<Exception> Exceptions { get; private set; }

        private readonly List<IValidation> _collection = new();

        public ValidationContext(TRequest request)
        {
            Exceptions = new();
            Request = request;
        }

        public void Add(IValidation validation) {
            _collection.Add(validation);
        }
        public bool Remove(IValidation validation)
        {
            return _collection.Remove(validation);
        }
        public IEnumerator<IValidation> GetEnumerator()
        {
            return new ValidationEnumerator(_collection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Validate()
        {
            ValidateBindedValiationAttributes();
            ValidateStuckValiationAttributes();

            foreach (var validation in _collection)
                validation.Validate();

            if (Exceptions.Count > 0)
                throw new ValidationException(Exceptions);
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
                        ToChackMinimumLimitAsBindedValidationAttributes(sourceProperty, targetProperty);
                        ToChackMaximumLimitAsBindedValidationAttributes(sourceProperty, targetProperty);
                        ToChackEmailAddressPatternAsBindedValidationAttributes(sourceProperty, targetProperty);
                    }
                }
            }
        }

        private void ValidateStuckValiationAttributes()
        {
            var sourceProperties = Request.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                if ((MinLengthAttribute)Attribute.
                    GetCustomAttribute(sourceProperty, typeof(MinLengthAttribute))! != null)
                    ToChackMinimumLimit(sourceProperty);

                if ((MaxLengthAttribute)Attribute.
                    GetCustomAttribute(sourceProperty, typeof(MaxLengthAttribute))! != null)
                    ToChackMaximumLimit(sourceProperty);

                if ((EmailAddressAttribute)Attribute.
                    GetCustomAttribute(sourceProperty, typeof(EmailAddressAttribute))! != null)
                    ToChackEmailAddressPattern(sourceProperty);
            }
        }

        private class ValidationEnumerator : IEnumerator<IValidation>
        {
            private List<IValidation> _collection;
            private int currentIndex = -1;

            public ValidationEnumerator(List<IValidation> collection)
            {
                _collection = collection;
            }

            IValidation Current => _collection[currentIndex];

            object IEnumerator.Current => Current;

            IValidation IEnumerator<IValidation>.Current => Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < _collection.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public void Dispose()
            {
            }
        }

        private void ToChackMinimumLimit(PropertyInfo sourceProperty)
        {
            ToChackMinimumLimitAsBindedValidationAttributes(sourceProperty, sourceProperty);
        }
        private void ToChackMinimumLimitAsBindedValidationAttributes(
            PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            var sourceValue = sourceProperty.GetValue(Request)!.ToString();

            var minLengthAttributeOfTarget = (MinLengthAttribute)Attribute.
                GetCustomAttribute(targetProperty, typeof(MinLengthAttribute))!;
            if (minLengthAttributeOfTarget != null)
            {
                if (sourceValue!.Length < minLengthAttributeOfTarget.Length)
                {
                    Exceptions.Add(
                        new FieldLengthIsLessThanMinimumLengthLimitException(
                            fieldName: sourceProperty.Name, minLength: minLengthAttributeOfTarget.Length));
                }
            }
        }

        private void ToChackMaximumLimit(PropertyInfo sourceProperty)
        {
            ToChackMaximumLimitAsBindedValidationAttributes(sourceProperty, sourceProperty);
        }
        private void ToChackMaximumLimitAsBindedValidationAttributes(
            PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            var sourceValue = sourceProperty.GetValue(Request)!.ToString();

            var maxLengthAttributeOfTarget = (MaxLengthAttribute)Attribute.
                GetCustomAttribute(targetProperty, typeof(MaxLengthAttribute))!;
            if (maxLengthAttributeOfTarget != null)
            {
                if (sourceValue!.Length > maxLengthAttributeOfTarget.Length)
                {
                    Exceptions.Add(
                        new FieldLengthIsMoreThanMaximumLengthLimitException(
                            fieldName: sourceProperty.Name, maxLength: maxLengthAttributeOfTarget.Length));
                }
            }
        }

        private void ToChackEmailAddressPattern(PropertyInfo sourceProperty)
        {
            ToChackEmailAddressPatternAsBindedValidationAttributes(sourceProperty, sourceProperty);
        }
        private void ToChackEmailAddressPatternAsBindedValidationAttributes(
            PropertyInfo sourceProperty, PropertyInfo targetProperty)
        {
            var sourceValue = sourceProperty.GetValue(Request)!.ToString();

            var emailAddressAttributeOfTarget = (EmailAddressAttribute)Attribute.
                GetCustomAttribute(targetProperty, typeof(EmailAddressAttribute))!;
            if (emailAddressAttributeOfTarget != null)
            {
                if(!string.IsNullOrEmpty(sourceValue))
                {
                    string pattern = $@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                    if (!new System.Text.RegularExpressions.Regex(pattern).IsMatch(sourceValue!))
                    {
                        Exceptions.Add(
                            new FieldIsNotAValidEamilAddressException(fieldName: sourceProperty.Name));
                    }
                }
            }
        }
    }
}