using XSwift.Base;
using XSwift.Properties;

namespace XSwift.Domain
{
    public class ValidationIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ValidationIssue(
            string outerDescription = "",
            string innerDescription = "")
        {
            Name = GetType().FullName!;

            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = Resource.Validation_Issue_ValidationError;
            if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
