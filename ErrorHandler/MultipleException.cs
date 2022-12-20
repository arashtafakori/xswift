namespace CoreX.Structure
{
    public class MultipleException : Exception
    {
        private string? _jsonString;

        public void SetJsonData(string jsonString)
        {
            _jsonString = Constants.MULTIPPLE_ERROR + jsonString;
        }

        public override string Message => _jsonString!;

        public List<Error> GetErrorResults()
        {
            return ErrorContext.GetErrorResults(_jsonString!);
        }
    }
}
    