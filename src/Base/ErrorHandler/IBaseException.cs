namespace XSwift.Base
{
    /// <summary>
    /// Represents the base interface for exceptions in the application.
    /// </summary>
    public interface IBaseException  
    {
        /// <summary>
        /// Gets the type of the exception.
        /// </summary>
        public string Type { get; }
    }
}
