namespace CoreX
{
    public class LogicalException : AggregateException
    {
        public LogicalException(List<Exception> exceptions)
            : base(exceptions)
        {
        }

        public LogicalException(string message) 
            : base(message)
        {
        }
    }
}
