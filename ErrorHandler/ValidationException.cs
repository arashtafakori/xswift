namespace Artaware.Infrastructure.CoreX
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) 
            : base(nameof(ExceptionType.Validation) + message)
        {
        }
    }
}
