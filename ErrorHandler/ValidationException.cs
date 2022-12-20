namespace CoreX.Structure
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) 
            : base(Constants.VALIDATION_ERROR + message)
        {
        }
    }
}
