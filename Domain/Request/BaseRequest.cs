namespace XSwift.Domain
{
    public abstract class BaseRequest
    {
        public ValidationState<BaseRequest> ValidationState { get; private set; }

        public BaseRequest()
        {
            ValidationState = new(this);
        }
    }
}
