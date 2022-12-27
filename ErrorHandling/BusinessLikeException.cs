namespace Artaco.Infrastructure.CoreX
{
    public class BusinessLikeException : Exception
    {
        public BusinessLikeException(string message) 
            : base(nameof(ExceptionType.BusinessLike) + message)
        {
        }
    }
}
