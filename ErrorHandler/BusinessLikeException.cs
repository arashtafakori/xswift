namespace CoreX.Structure
{
    public class BusinessLikeException : Exception
    {
        public BusinessLikeException(string message) 
            : base(Constants.BUSINESSLIKE_ERROR + message)
        {
        }
    }
}
