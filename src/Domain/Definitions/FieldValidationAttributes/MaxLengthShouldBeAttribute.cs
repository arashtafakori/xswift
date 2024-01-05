using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Specifies that the maximum length of a string or array field should be limited to the specified value.
    /// </summary>
    public class MaxLengthShouldBeAttribute : FieldValidationAttribute
    {
        /// <summary>
        /// Gets the maximum allowed length for the field.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxLengthShouldBeAttribute"/> class with the specified maximum length.
        /// </summary>
        /// <param name="length">The maximum allowed length for the field.</param>
        public MaxLengthShouldBeAttribute(int length)
        {
            Length = length;
        }

        /// <summary>
        /// Determines whether the specified value is valid based on the maximum length constraint.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns><c>true</c> if the value is valid or null; otherwise, <c>false</c>.</returns>
        public override bool IsValid(object? value)
        {
            EnsureLengthsIsAllowed();

            var length = 0;
            if (value == null)
            {
                return true;
            }
            else
            {
                var str = value as string;
                if (str != null)
                {
                    length = str.Length;
                }
                else
                {
                    length = ((Array)value).Length;
                }
            }

            return length <= Length;
        }

        /// <summary>
        /// Validates the specified value based on the maximum length constraint and adds an issue if the validation fails.
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
                    new FieldLengthIsMoreThanMaximumLengthLimit(
                        fieldName: propertyName,
                        maxLength: Length,
                        description: Description!));
            }
        }

        /// <summary>
        /// Ensures that the specified maximum length is allowed (greater than zero).
        /// </summary>
        internal void EnsureLengthsIsAllowed()
        {
            if (Length == 0 || Length < -1)
            {
                throw new InvalidOperationException("The {0} filed must have a Length value that is greater than zero.");
            }
        }
    }
}
