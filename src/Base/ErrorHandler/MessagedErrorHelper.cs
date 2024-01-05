using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace XSwift.Base
{
    /// <summary>
    /// Helper class providing methods for working with serialized errors.
    /// An example of an serialized error: "This is a <Error>:  {type: validation, issues: [{name:"...", description"..."},{name:"...", description"..."}]}";
    /// </summary>
    internal static class MessagedErrorHelper
    {
        private static readonly string ErrorKey = "<Error>:";
        private static readonly string ErrorPattern = @$"^.*({ErrorKey})(.*)$";

        /// <summary>
        /// Retrieves an <see cref="Error"/> instance from an error message.
        /// </summary>
        /// <param name="message">The error message containing the serialized error information.</param>
        /// <returns>An <see cref="Error"/> instance if the message contains a serialized error; otherwise, null.</returns>
        public static Error? RetrieceError(string message)
        {
            Match match = Regex.Match(message, ErrorPattern);

            if (match.Success)
            {
                return JsonConvert.DeserializeObject<Error>(match.Groups[2].Value);
            }
            return null;
        }

        /// <summary>
        /// Checks whether the given message represents an error exception.
        /// </summary>
        /// <param name="message">The message to check for being an error exception.</param>
        /// <returns>True if the message represents an error exception; otherwise, false.</returns>
        public static bool IsErrorException(string message)
        {
            return new Regex(ErrorPattern).IsMatch(message);
        }

        /// <summary>
        /// Converts an <see cref="Error"/> instance to an error message.
        /// </summary>
        /// <param name="error">The error instance to be converted to a message.</param>
        /// <returns>The error message containing the serialized error information.</returns>
        public static string ConvertToErrorMessage(Error error) {
            return ErrorKey + JsonConvert.SerializeObject(error);
        }
    }
}
