namespace XSwift.Domain
{
    public abstract class BaseRequest
    {
        public ValidationState<BaseRequest> ValidationState { get; private set; }
        public InvariantState InvariantState { get; private set; }
        public BaseRequest()
        {
            ValidationState = new(this);
            InvariantState = new();
        }

        public void SetInvariantState(InvariantState invariantState)
        {
            InvariantState = invariantState;
        }
    }
}
