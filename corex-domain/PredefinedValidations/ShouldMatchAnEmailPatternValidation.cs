using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Domain
{
    public class ShouldMatchAnEmailPatternValidation<TRequest> : IValidation
    {
        private readonly Expression<Func<TRequest, object>> _property;
        private readonly Request _request;

        public ShouldMatchAnEmailPatternValidation(
            Request request,
            Expression<Func<TRequest, object>> property)
        {
            _request = request;
            _property = property;
        }

        public bool IsValid()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;
            var value = propertyInfo!.GetValue(_request)!.ToString()!;

            string pattern = $@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (!new System.Text.RegularExpressions.Regex(pattern).IsMatch(value!.ToString()!))
                return false;

            return true;
        }

        public void Validate()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            if (!IsValid())
                _request.ValidationState.AddIssue(
                    new FieldIsNotAValidEamilAddressIssue(fieldName: propertyInfo!.Name!));
        }
    }
}
