using System.Text.Json;

namespace CoreX.Structure
{
    public sealed class MultipleExceptionFactory : MultipleException
    {
        public MultipleExceptionFactory()
        {
            _exceptions = new List<PrimitiveError>();
        }

        public void AppendError(PrimitiveError error)
        {
            _exceptions.Add(error);
        }
        public void ClearErrors()
        {
            _exceptions = new List<PrimitiveError>();
        }

        public void Throw()
        {
            string jsonString = JsonSerializer.Serialize(_exceptions);
            var exception = Activator.CreateInstance<MultipleException>();
            exception.SetJsonData(jsonString);
            throw exception;
        }

        private IList<PrimitiveError> _exceptions;
    }
}
    