namespace CoreX.AdvancedFeatures.MassTransit
{
    public interface IRequestMessage
    {
    }
    public interface IRequestMessage<out TResponse> : IRequestMessage
    {
    }
}
