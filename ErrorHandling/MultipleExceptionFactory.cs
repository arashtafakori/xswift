using System.Text.Json;

namespace Artaco.Infrastructure.CoreX
{
    public sealed class MultipleExceptionFactory : MultipleException
    {
        public MultipleExceptionFactory()
        {
            _exceptions = new List<BasicError>();
        }

        public void AppendError(BasicError error)
        {
            _exceptions.Add(error);
        }
        public void ClearErrors()
        {
            _exceptions = new List<BasicError>();
        }

        public void Throw()
        {
            string jsonString = JsonSerializer.Serialize(_exceptions);
            var exception = Activator.CreateInstance<MultipleException>();
            exception.SetJsonData(jsonString);
            throw exception;
        }

        private IList<BasicError> _exceptions;
    }
}
    