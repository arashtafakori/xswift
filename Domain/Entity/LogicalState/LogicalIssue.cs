using XSwift.Base;
using XSwift.Properties;

namespace XSwift.Domain
{
    public class LogicalIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public void Provide<TLogicalIssue>(
            string outerDescription,
            string innerDescription)
            where TLogicalIssue : LogicalIssue
        {
            Name = typeof(TLogicalIssue).FullName!;

            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = Resource.Logical_Issue_LogicalError;
            else if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            else if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
