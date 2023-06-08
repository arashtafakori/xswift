using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Domain
{
    public class ShouldBeUsernameValidation<TRequest> : IValidation
    {
        private readonly Expression<Func<TRequest, object>> _property;
        private readonly LogicalRequest _request;

        public ShouldBeUsernameValidation(
            LogicalRequest request,
            Expression<Func<TRequest, object>> property)
        {
            _request = request;
            _property = property;
        }

        public bool IsValid()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            var pattern = "^[A-Za-z0-9_]$";

            var value = propertyInfo!.GetValue(_request);
            if (!new System.Text.RegularExpressions.Regex(pattern).IsMatch(value!.ToString()!))
                return false;

            return true;
        }

        public void Validate()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            if (!IsValid())
                _request.Validation.Exceptions.Add(
                    new FieldIsNotAValidUsernameException(fieldName: propertyInfo!.Name!));
        }
    }
}
