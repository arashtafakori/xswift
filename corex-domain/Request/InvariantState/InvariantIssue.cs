using CoreX.Base;
using CoreX.Domain.Properties;

namespace CoreX.Domain
{
    public class InvariantIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public void Provide<TInvariantIssue>(
            string outerDescription,
            string innerDescription)
            where TInvariantIssue : InvariantIssue
        {
            Name = typeof(TInvariantIssue).FullName!;

            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = Resource.Invariant_Issue_InvariantError;
            else if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            else if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
