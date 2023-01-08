//namespace Artaware.Infrastructure.CoreX
//{
//    public class MultipleException : Exception
//    {
//        private string _jsonString = string.Empty;

//        public void SetJsonData(string jsonString)
//        {
//            _jsonString = nameof(ExceptionType.Multipile) + jsonString;
//        }

//        public override string Message => _jsonString!;

//        public List<TraceableError> GetErrorResults()
//        {
//            return ErrorContext.GetErrorResults(_jsonString!);
//        }
//    }
//}
    