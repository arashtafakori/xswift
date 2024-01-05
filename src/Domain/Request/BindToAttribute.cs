namespace XSwift.Domain
{
    /// <summary>
    /// Represents an attribute that binds the target property to a specified property in another type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BindToAttribute : Attribute
    {
        /// <summary>
        /// Gets the type of the target property's container.
        /// </summary>
        public Type TargetType { get; }

        /// <summary>
        /// Gets the name of the property in the target type to which the property is bound.
        /// </summary>
        public string TargetPropertyName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindToAttribute"/> class with the specified target type and property name.
        /// </summary>
        /// <param name="targetType">The type of the target property's container.</param>
        /// <param name="targetPropertyName">The name of the property in the target type to which the property is bound.</param>
        public BindToAttribute(Type targetType, string targetPropertyName)
        {
            TargetType = targetType;
            TargetPropertyName = targetPropertyName;
        }
    }
}
