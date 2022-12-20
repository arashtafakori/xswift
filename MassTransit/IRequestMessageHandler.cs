namespace CoreX.Structure
{
    public interface IRequestMessageHandler<TRequest, TResult> where TRequest : INotificationMessage
    {
        public Task<TResult> Handle(TRequest request);
    }
}
