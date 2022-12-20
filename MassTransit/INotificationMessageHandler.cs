namespace CoreX.Structure
{
    public interface INotificationMessageHandler<TRequest> where TRequest : INotificationMessage
    {
        public Task Handle(TRequest request);
    }
}
