namespace CoreX.Structure
{
    public class StringResponse
    {
        public StringResponse(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}
