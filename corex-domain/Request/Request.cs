using Newtonsoft.Json;

namespace CoreX.Domain
{
    public abstract class Request
    {
        public ValidationState<Request> ValidationState { get; private set; }
        public Request()
        {
            ValidationState = new(this);
        }
    }
}
