namespace Artaco.Infrastructure.CoreX
{
    public class ValidatingException : Exception
    {
        public ValidatingException(string message) 
            : base(nameof(ExceptionType.Validating) + message)
        {
        }
    }
}
