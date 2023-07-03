using CoreX.Base;
using MediatR;

namespace CoreX.Domain
{
    public interface IInvariant
    {
        public Task<bool> Check(IMediator mediator);
        public Issue? GetIssue();
     }
}
