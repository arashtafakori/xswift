namespace XSwift.Base
{
    /// <summary>
    /// Represents a static class providing a global instance of some state and confguration like the <see cref="Environment"/>.
    /// </summary>
    public static class XService
    {    /// <summary>
         /// Gets the global instance of the <see cref="Environment"/> representing the service environment.
         /// </summary>
        public readonly static Environment Environment = new Environment();
	}
}
