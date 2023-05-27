namespace CoreX.AdvancedFeatures.MassTransit
{
    public interface IRequestMessageHandler<TRequest, TResult> where TRequest : INotificationMessage
    {
        public Task<TResult> Handle(TRequest request);
    }
}
