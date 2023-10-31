namespace XSwift.Domain
{
    public abstract class BaseQueryItemRequestByKey<KeyType, TReturnedType>
        : BaseQueryRequest<TReturnedType>
    {
        public KeyType KeyValue { get; private set; }

        public BaseQueryItemRequestByKey(KeyType keyValue)
        {
            KeyValue = keyValue;
        }

        public BaseQueryItemRequestByKey<KeyType, TReturnedType> SetKeyValue(KeyType value)
        {
            KeyValue = value;

            return this;
        }
    }
}
