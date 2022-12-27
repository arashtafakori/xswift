namespace Artaco.Infrastructure.CoreX
{
    public interface INotificationMessageHandler<TRequest> where TRequest : INotificationMessage
    {
        public Task Handle(TRequest request);
    }
}
