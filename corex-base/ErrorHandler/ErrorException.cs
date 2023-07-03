namespace CoreX.Base
{
    public class ErrorException : Exception
    {
        public Error Error { get; private set; }

        public ErrorException(Error error) : base(
            ExceptionHelper.ConvertToErrorMessage(error))
        {
            Error = error;
        }
    }
}
