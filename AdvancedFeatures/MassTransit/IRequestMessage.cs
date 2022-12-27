namespace Artaco.Infrastructure.CoreX
{
    public interface IRequestMessage
    {
    }
    public interface IRequestMessage<out TResponse> : IRequestMessage
    {
    }
}
