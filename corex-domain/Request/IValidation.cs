using System.Linq.Expressions;

namespace CoreX.Domain
{
    public interface IValidation
    {
        void Validate();

        bool IsValid();
    }
}
