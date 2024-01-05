namespace XSwift.Base
{
    /// <summary>
    /// Represents an exception thrown in response to an application error, encapsulating detailed error information.
    /// </summary>
    public class ErrorException : Exception
    {
        /// <summary>
        /// Gets the detailed error information associated with the exception.
        /// </summary>
        public Error Error { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorException"/> class with a specific error.
        /// </summary>
        /// <param name="error">The detailed error information to be associated with the exception.</param>
        public ErrorException(Error error) : base(
            MessagedErrorHelper.ConvertToErrorMessage(error))
        {
            Error = error;
        }
    }
}
