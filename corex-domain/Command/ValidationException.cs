namespace CoreX.Domain
{
    public class ValidationException : AggregateException
    {
        public ValidationException(List<Exception> exceptions)
            : base(exceptions)
        {
        }

        public ValidationException(string message) : base(message)
        {
        }
    }
}
