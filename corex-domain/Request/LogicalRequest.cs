namespace CoreX.Domain
{
    public abstract class LogicalRequest
    {
        public ValidationContext<LogicalRequest> Validation { get; private set; }

        public LogicalRequest()
        {
            Validation = new(this);
        }
    }
}
