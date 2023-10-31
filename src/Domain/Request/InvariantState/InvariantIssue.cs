using XSwift.Base;
using XSwift.Properties;

namespace XSwift.Domain
{
    public class InvariantIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public InvariantIssue(
            string outerDescription,
            string innerDescription)
        {
            Name = GetType().FullName!;

            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = Resource.Invariant_Issue_InvariantError;
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
