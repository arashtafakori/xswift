using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace CoreX.Base
{
    public static class ExceptionHelper
    {
        private static readonly string ErrorKey = "<Error>:";
        private static readonly string ErrorPattern = @$"^.*({ErrorKey})(.*)$";
        /// <summary>
        /// A message example: "This is a <Error>:  {type: validation, issues: [{name:"...", description"..."},{name:"...", description"..."}]}";
        /// </summary>
        /// <returns></returns>
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
        /// A message example: "This is a <Error>: {type: validation, issues: [{name:"...", description"..."},{name:"...", description"..."}]}";
        /// </summary>
        /// <returns></returns>
        public static bool IsErrorException(string message)
        {
            return new Regex(ErrorPattern).IsMatch(message);
        }

        /// <summary>
        /// A returned message example: "This is a <Error>: {type: validation, issues: [{name:"...", description"..."},{name:"...", description"..."}]}";
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string ConvertToErrorMessage(Error error) {
            return ErrorKey + JsonConvert.SerializeObject(error);
        }
    }
}
