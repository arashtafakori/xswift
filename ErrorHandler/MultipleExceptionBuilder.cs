using System.Text.Json;

namespace Artaware.Infrastructure.CoreX
{
    public sealed class MultipleExceptionBuilder : MultipleException
    {
        public MultipleExceptionBuilder()
        {
            _exceptions = new List<Error>();
        }

        public void AppendError(Error error)
        {
            _exceptions.Add(error);
        }
        public void ClearErrors()
        {
            _exceptions = new List<Error>();
        }

        public MultipleException Build()
        {
            string jsonString = JsonSerializer.Serialize(_exceptions);
            var exception = Activator.CreateInstance<MultipleException>();
            exception.SetJsonData(jsonString);
            return exception;
        }

        private IList<Error> _exceptions;
    }
}
    