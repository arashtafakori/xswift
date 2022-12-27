namespace Artaco.Infrastructure.CoreX
{
    public class GuidResponse
    {
        public GuidResponse(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; private set; }
    }
}
