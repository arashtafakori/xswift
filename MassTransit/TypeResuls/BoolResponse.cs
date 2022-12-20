namespace CoreX.Structure
{
    public class BoolResponse
    {
        public BoolResponse(bool value)
        {
            Value = value;
        }

        public bool Value { get; private set; }
    }
}
