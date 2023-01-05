using System.Globalization;
using System.Resources;

namespace Artaware.Infrastructure.CoreX
{
    public static class ResourceManagerExtentions
    {
        public static string ResolveErrorMessage(this ResourceManager source, string errorCode)
        {
            string? result = source.GetString(errorCode);
            if (string.IsNullOrEmpty(result))
                throw new ArgumentNullException(
                    string.Format(CultureInfo.CurrentCulture, 
                    "No message for this {0} and this language was found.", errorCode));

            return result;
        }
    }
}
