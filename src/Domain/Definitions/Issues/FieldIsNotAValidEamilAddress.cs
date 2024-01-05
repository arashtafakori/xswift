using System.Globalization;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents an invariant issue that occurs when validating a field and its value is not a valid email address.
    /// </summary>
    public class FieldIsNotAValidEamilAddress : ValidationIssue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldIsNotAValidEmailAddress"/> class
        /// with the specified field name and description.
        /// </summary>
        /// <param name="fieldName">The name of the field with an invalid email address.</param>
        /// <param name="description">A custom description for the invariant issue (optional).</param>
        public FieldIsNotAValidEamilAddress(
            string fieldName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                "The {0} field as email adress is not the same as a valid email address.",
                fieldName))
        {
        }
    }
}
