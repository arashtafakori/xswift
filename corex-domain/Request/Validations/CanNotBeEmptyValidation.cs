using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Domain
{
    public class CanNotBeEmptyValidation<TRequest> : IValidation
    {
        private readonly Expression<Func<TRequest, object>> _property;
        private readonly LogicalRequest _request;
        private readonly bool _allowEmptyStrings;

        public CanNotBeEmptyValidation(
            LogicalRequest request,
            Expression<Func<TRequest, object>> property,
            bool allowEmptyStrings)
        {
            _request = request;
            _property = property;
            _allowEmptyStrings = allowEmptyStrings;
        }

        public bool IsValid()
        {
             var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            var value = propertyInfo!.GetValue(_request);
            if (value == null)
                return false;

            // only check string length if empty strings are not allowed
            var stringValue = value as string;
            if (stringValue != null && !_allowEmptyStrings)
            {
                if (stringValue.Trim().Length != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// An Example:
        /// Rules.CanNotBeEmpty(c => c.Username,
        /// condition: Account.Property(e => e.Username).IsRequired,
        /// allowEmptyStrings: Account.Property(e => e.Username).IsEmptyStringsAllowed);
        /// </summary>
        /// <param name="property"></param>
        /// <param name="condition"></param>
        /// <param name="allowEmptyStrings"></param>
        public void Validate()
        {
            var propertyInfo = ((MemberExpression)_property.Body).Member as PropertyInfo;

            if (!IsValid())
                _request.Validation.Exceptions.Add(new FieldIsNullException(propertyInfo!.Name!));
        }
     }
}
