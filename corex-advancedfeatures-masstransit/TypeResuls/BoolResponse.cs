namespace CoreX.AdvancedFeatures.MassTransit
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
