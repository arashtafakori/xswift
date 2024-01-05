using System.Globalization;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents an invariant issue that occurs when validating a field, and its length is more than the specified maximum length limit.
    /// </summary>
    public class FieldLengthIsMoreThanMaximumLengthLimit : ValidationIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldLengthIsMoreThanMaximumLengthLimit"/> class
        /// with the specified maximum length, field name, and description.
        /// </summary>
        /// <param name="maxLength">The maximum allowed length for the field.</param>
        /// <param name="fieldName">The name of the field with a length more than the maximum length limit.</param>
        /// <param name="description">A custom description for the invariant issue (optional).</param>
        public FieldLengthIsMoreThanMaximumLengthLimit(
            int maxLength, string fieldName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "The {0} field maximum length is more than the maximum length pageSize. The field's length should be less than {1} characters."
                    , fieldName, maxLength))
        {
        }
    }
}
