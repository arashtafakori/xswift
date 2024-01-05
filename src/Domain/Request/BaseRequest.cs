using Newtonsoft.Json;

namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for domain requests with the built-in validation state.
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// Gets the validation state associated with the request.
        /// </summary>
        [JsonIgnore]
        public ValidationState<BaseRequest> ValidationState { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRequest"/> class.
        /// </summary>
        public BaseRequest()
        {
            // Initialize the validation state for the request.
            ValidationState = new(this);
        }
    }
}
