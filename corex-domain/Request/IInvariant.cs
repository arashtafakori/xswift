using CoreX.Base;
using MediatR;

namespace CoreX.Domain
{
    public interface IInvariant
    {
        public Task<bool> CheckAsync(IMediator mediator);
        public IIssue? GetIssue();
     }
}
