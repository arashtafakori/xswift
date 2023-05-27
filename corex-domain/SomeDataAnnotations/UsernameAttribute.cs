using CoreX.Domain.Properties;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CoreX.Domain
{
    public class UsernameAttribute : ValidationAttribute
    {
        public readonly int _minLength;
        public readonly int _maxLength;
        public UsernameAttribute(int minLength, int maxLength) :
            base(() => DefaultErrorMessageString)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        private static string DefaultErrorMessageString
        {
            get { return string.Format(CultureInfo.CurrentCulture,
                    Resource.FieldIsNotAValidUsername_ValidationError); }
        }

        /// <summary>
        /// Determines whether a specified object is valid. (Overrides <see cref = "ValidationAttribute.IsValid(object)" />)
        /// </summary>
        /// <remarks>
        /// This method returns <c>true</c> if the <paramref name = "value" /> is null.  
        /// It is assumed the <see cref = "RequiredAttribute" /> is used if the value may not be null.
        /// </remarks>
        /// <param name = "value">The object to validate.</param>
        /// <returns><c>true</c> if the value is null or is not valid username, otherwise <c>false</c></returns>
        /// <exception cref = "InvalidOperationException">Length is zero or less than negative one.</exception>
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var pattern = "^[A-Za-z][A-Za-z0-9_]{" + _minLength + "," + _maxLength + "}$";

            var valueAsString = value as string;

            if (valueAsString != null && new System.Text.RegularExpressions.Regex(pattern).IsMatch(valueAsString))
                return false;

            return true;
        }

        /// <summary>
        /// Applies formatting to a specified error message. (Overrides <see cref = "ValidationAttribute.FormatErrorMessage" />)
        /// </summary>
        /// <param name = "name">The name to include in the formatted string.</param>
        /// <returns>A localized string to describe the acceptable username.</returns>
        public override string FormatErrorMessage(string name)
        {
            // An error occurred, so we know the value is not like a acceptable username.
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}
