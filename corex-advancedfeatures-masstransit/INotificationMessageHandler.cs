namespace CoreX.AdvancedFeatures.MassTransit
{
    public interface INotificationMessageHandler<TRequest> where TRequest : INotificationMessage
    {
        public Task Handle(TRequest request);
    }
}
