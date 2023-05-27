using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Domain
{
    public abstract class Validator<TCommand>
    {
        private readonly List<Exception> _exceptions = new();

        public readonly ValidationRules<TCommand> Rules;

        public Validator()
        {
            Rules = new(_exceptions);
        }

        public void Validate()
        {
            if (_exceptions.Count > 0)
                throw new ValidationException(_exceptions);
        }
    }
}
