using XSwift.Base;

namespace XSwift.Domain
{
    /// <summary>
    /// Specifies that the minimum length of a string or array field should be limited to the specified value.
    /// </summary>
    public class MinLengthShouldBeAttribute : FieldValidationAttribute
    {
        /// <summary>
        /// Gets the minimum allowed length for the field.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinLengthShouldBeAttribute"/> class with the specified minimum length.
        /// </summary>
        /// <param name="length">The minimum allowed length for the field.</param>
        public MinLengthShouldBeAttribute(int length)
        {  
            Length = length;
        }

        /// <summary>
        /// Determines whether the specified value is valid based on the minimum length constraint.
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

            return length >= Length;
        }

        /// <summary>
        /// Validates the specified value based on the minimum length constraint and adds an issue if the validation fails.
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
                    new FieldLengthIsLessThanMinimumLengthLimit(
                        fieldName: propertyName,
                        minLength: Length,
                        description: Description!));
            }
        }

        /// <summary>
        /// Ensures that the specified minimum length is legal (zero or greater).
        /// </summary>
        internal void EnsureLengthsIsAllowed()
        {
            if (Length < 0)
            {
                throw new InvalidOperationException("The {0} field must have a Length value that is zero or greater.");
            }
        }
    }
}
