namespace CoreX.Domain
{
    public class InvariantException : AggregateException
    {
        public InvariantException(List<Exception> exceptions)
            : base(exceptions)
        {
        }

        public InvariantException(string message) 
            : base(message)
        {
        }
    }
}
