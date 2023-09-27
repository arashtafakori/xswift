namespace XSwift.Domain
{
    public abstract class BaseQueryItemRequestByKey<KeyType>
        : BaseQueryRequest
    {
        public KeyType KeyValue { get; private set; }
        public void SetKeyValue(KeyType value)
        {
            KeyValue = value;
        }
        public BaseQueryItemRequestByKey(KeyType keyValue)
        {
            KeyValue = keyValue;
        }
    }
}
