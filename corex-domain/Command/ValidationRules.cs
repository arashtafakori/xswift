using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Domain
{
    public class ValidationRules<TCommand>
    {
        private readonly List<Exception> _exceptions;
 
        public ValidationRules(List<Exception> exceptions)
        {
            _exceptions = exceptions;
        }

        public void ShouldBeUsername(
            Expression<Func<TCommand, string>> property,
            int minLength, int maxLength)
        {
            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
            
            var pattern = "^[A-Za-z][A-Za-z0-9_]{" + minLength + "," + maxLength + "}$";

            var value = propertyInfo!.GetValue(this);
            if (!new System.Text.RegularExpressions.Regex(pattern).IsMatch(value!.ToString()!))
                AppendException(new FieldIsNotAValidUsernameException(
                    minLength, maxLength,filedName: propertyInfo.Name!));
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
        public void CanNotBeEmpty(
            Expression<Func<TCommand, object>> property,
            bool condition = true,
            bool allowEmptyStrings = false)
        {
            if (condition == false)
                return;

            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
     
            var value = propertyInfo!.GetValue(this);
            if (value == null)
                AppendException(new FieldIsNullException(propertyInfo.Name!));

            // only check string length if empty strings are not allowed
            var stringValue = value as string;
            if (stringValue != null && !allowEmptyStrings)
            {
                if (stringValue.Trim().Length != 0)
                    AppendException(new FieldIsNullException(propertyInfo.Name!));
            }
        }

        private void AppendException(ValidationException exception)
        {
            _exceptions.Add(exception);
        }
    }
}
