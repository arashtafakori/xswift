using System.Text.Json;

namespace CoreX.Base.Helpers.ErrorHelper
{
    public sealed class MultipleExceptionBuilder : MultipleException
    {
        private IList<BasicError> _exceptions;
        public MultipleExceptionBuilder()
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

        public MultipleException Build()
        {
            string jsonString = JsonSerializer.Serialize(_exceptions);
            var exception = Activator.CreateInstance<MultipleException>();
            exception.SetJsonData(jsonString);
            return exception;
        }
    }
}
