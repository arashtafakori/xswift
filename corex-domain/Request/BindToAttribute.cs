namespace CoreX.Domain
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BindToAttribute : Attribute
    {
        public Type TargetType { get; }
        public string TargetPropertyName { get; }

        public BindToAttribute(Type targetType, string targetPropertyName)
        {
            TargetType = targetType;
            TargetPropertyName = targetPropertyName;
        }
    }
}
