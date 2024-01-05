namespace XSwift.Domain
{
    /// <summary>
    /// Represents a base class for query requests targeting a single item by a key, with optional pagination settings.
    /// </summary>
    /// <typeparam name="KeyType">The type of the key used to identify the requested item.</typeparam>
    /// <typeparam name="TReturnedType">The type of the result returned by the query.</typeparam>
    public abstract class BaseQueryItemRequestByKey<KeyType, TReturnedType>
        : BaseQueryRequest<TReturnedType>
    {
        /// <summary>
        /// Gets or sets the key value used to identify the requested item.
        /// </summary>
        public KeyType KeyValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseQueryItemRequestByKey{KeyType, TReturnedType}"/> class with the specified key value.
        /// </summary>
        /// <param name="keyValue">The key value used to identify the requested item.</param>
        public BaseQueryItemRequestByKey(KeyType keyValue)
        {
            KeyValue = keyValue;
        }

        /// <summary>
        /// Sets the key value used to identify the requested item.
        /// </summary>
        /// <param name="value">The new value for the key.</param>
        /// <returns>The current instance of the query request for fluent chaining.</returns>
        public BaseQueryItemRequestByKey<KeyType, TReturnedType> SetKeyValue(KeyType value)
        {
            KeyValue = value;

            return this;
        }
    }
}
