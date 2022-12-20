namespace CoreX.Structure
{
    public interface IRequestMessage
    {
    }
    public interface IRequestMessage<out TResponse> : IRequestMessage
    {
    }
}
