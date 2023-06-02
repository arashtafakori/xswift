using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Domain
{
    public class ShouldBeUsernameValidation<TCommand> : IValidation
    {
        private readonly Expression<Func<TCommand, object>> _property;
        private readonly Command _command;
        private readonly int _minLength;
        private readonly int _maxLength;

        public ShouldBeUsernameValidation(
            Command command,
            Expression<Func<TCommand, object>> property,
            int minLength, 
            int maxLength)
        {
            _command = command;
            _property = property;
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public bool IsValid()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            var pattern = "^[A-Za-z0-9_]{" + _minLength + "," + _maxLength + "}$";

            var value = propertyInfo!.GetValue(_command);
            if (!new System.Text.RegularExpressions.Regex(pattern).IsMatch(value!.ToString()!))
                return false;

            return true;
        }

        public void Validate()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            if (!IsValid())
                _command.Validation.Exceptions.Add(
                    new FieldIsNotAValidUsernameException(
                        _minLength, _maxLength, fieldName: propertyInfo!.Name!));
        }
    }
}
