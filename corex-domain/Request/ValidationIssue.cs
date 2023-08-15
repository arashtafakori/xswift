using CoreX.Base;
using System.Globalization;

namespace CoreX.Domain
{
    public class ValidationIssue : IIssue
    {
        public ValidationIssue(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
                Description += string.Format(CultureInfo.CurrentCulture, errorMessage);

            if (!string.IsNullOrEmpty(Description))
                Description += "\r\n";
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
