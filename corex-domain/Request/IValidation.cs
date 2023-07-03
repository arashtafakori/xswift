using CoreX.Base;

namespace CoreX.Domain
{
    public interface IValidation
    {
        void Validate();

        bool IsValid();
    }
}
