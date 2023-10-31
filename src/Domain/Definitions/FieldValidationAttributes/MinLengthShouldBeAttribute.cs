using XSwift.Base;
using XSwift.Properties;

namespace XSwift.Domain
{
    public class MinLengthShouldBeAttribute : FieldValidationAttribute
    {
        public int Length { get; }
        public MinLengthShouldBeAttribute(int length)
        {  
            Length = length;
        }
        public override bool IsValid(object? value)
        {
            // Check the lengths for legality
            EnsureLegalLengths();

            var length = 0;
            // Automatically pass if value is null. RequiredAttribute should be used to assert a value is not null.
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
                    // We expect a cast exception if a non-{string|array} property was passed in.
                    length = ((Array)value).Length;
                }
            }

            return length >= Length;
        }
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
        ///     Checks that Length has a legal value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Length is less than zero.</exception>
        private void EnsureLegalLengths()
        {
            if (Length < 0)
            {
                throw new InvalidOperationException(Resource.Validation_Issue_MinLengthShouldBeAttributeMustHaveAValidLength);
            }
        }
    }
}
