using CoreX.Base;
using CoreX.Domain.Properties;

namespace CoreX.Domain
{
    public class ValidationIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public void Provide<TValidationIssue>(
            string outerDescription = "",
            string innerDescription = "")
            where TValidationIssue : ValidationIssue
        {
            Name = typeof(TValidationIssue).FullName!;

            if (string.IsNullOrEmpty(innerDescription) && string.IsNullOrEmpty(outerDescription))
                Description = Resource.Validation_Issue_ValidationError;
            else if (!string.IsNullOrEmpty(innerDescription))
                Description = innerDescription;
            else if (!string.IsNullOrEmpty(outerDescription))
                Description = outerDescription;
        }
    }
}
