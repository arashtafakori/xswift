using CoreX.Base;
using FluentAssertions;
using FluentAssertions.Specialized;
using MassTransit.Initializers;

namespace CoreX.TestingFacilities
{
    public static class FluentAssertionsExtentions
    {
        public static async Task BeSatisfiedWith<TIssue>(
            this NonGenericAsyncFunctionAssertions nonGenericAsyncFunctionAssertions) where TIssue : Issue
        {
            (await nonGenericAsyncFunctionAssertions.
                ThrowExactlyAsync<ErrorException>().
                Select(x => x.Which.Error.Issues.OfType<TIssue>()
                .Count())).Should().BeGreaterThan(0);
        }
    }
}
