namespace Artaco.Infrastructure.CoreX
{
    public class MultipleException : Exception
    {
        private string? _jsonString;

        public void SetJsonData(string jsonString)
        {
            _jsonString = nameof(ExceptionType.Multipile) + jsonString;
        }

        public override string Message => _jsonString!;

        public List<AdvancedError> GetErrorResults()
        {
            return ErrorContext.GetErrorResults(_jsonString!);
        }
    }
}
    