using Newtonsoft.Json;

namespace XSwift.Domain
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        public ValidationState<BaseRequest> ValidationState { get; private set; }

        public BaseRequest()
        {
            ValidationState = new(this);
        }
    }
}
