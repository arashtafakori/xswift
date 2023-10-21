using XSwift.Base;
using XSwift.Properties;

namespace XSwift.Domain
{
    public class LogicalIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public LogicalIssue(
            string outerDescription,
            string innerDescription)
        {
            Name = GetType().FullName!;

            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = Resource.Logical_Issue_LogicalError;
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
