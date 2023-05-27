using System.ComponentModel.DataAnnotations;

namespace CoreX.Domain
{
    public abstract class Command<TCommand> : Validator<TCommand>
    {
    }
}
