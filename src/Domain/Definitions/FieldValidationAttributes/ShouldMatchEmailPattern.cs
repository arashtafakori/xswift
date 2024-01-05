using XSwift.Base;
using System.Text.RegularExpressions;

namespace XSwift.Domain
{
    /// <summary>
    /// Specifies that the value of the field should match the standard email pattern.
    /// </summary>
    public class ShouldMatchEmailPattern : FieldValidationAttribute
    {
        // The regular expression for matching standard email patterns.
        private static Regex _regex = CreateRegExForMatchingStandardEmail();

        /// <summary>
        /// Determines whether the specified value is a valid email address based on the standard email pattern.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns><c>true</c> if the value is a valid email address; otherwise, <c>false</c>.</returns>
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            string? valueAsString = value as string;

            // Use RegEx implementation if it has been created, otherwise use a non RegEx version.
            if (_regex != null)
            {
                return valueAsString != null && _regex.Match(valueAsString).Length > 0;
            }
            else
            {
                int atCount = 0;

                foreach (char c in valueAsString!)
                {
                    if (c == '@')
                    {
                        atCount++;
                    }
                }

                return (valueAsString != null
                && atCount == 1
                && valueAsString[0] != '@'
                && valueAsString[valueAsString.Length - 1] != '@');
            }
        }

        /// <summary>
        /// Validates the specified value based on the standard email pattern and adds an issue if the validation fails.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="_issues">The collection of issues to which an issue may be added.</param>
        /// <param name="propertyName">The name of the property being validated.</param>
        public override void Validate(
            object? value,
            ICollection<IIssue> _issues,
            string propertyName = "")
        {
            if (!IsValid(value))
            {
                _issues.Add(
                    new FieldIsNotAValidEamilAddress(
                        fieldName: propertyName,
                        description: Description!));
            }
        }

        /// <summary>
        /// Creates a regular expression for matching standard email patterns.
        /// </summary>
        /// <returns>A regular expression for matching standard email patterns.</returns>
        internal static Regex CreateRegExForMatchingStandardEmail()
        {
            const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

            // Set explicit regex match timeout, sufficient enough for email parsing
            // Unless the global REGEX_DEFAULT_MATCH_TIMEOUT is already set
            TimeSpan matchTimeout = TimeSpan.FromSeconds(2);

            try
            {
                if (AppDomain.CurrentDomain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") == null)
                {
                    return new Regex(pattern, options, matchTimeout);
                }
            }
            catch
            {
                // Fallback on error
            }

            // Legacy fallback (without explicit match timeout)
            return new Regex(pattern, options);
        }
    }
}
