namespace CoreX.Structure
{
    public static class CommonRegexPatterns
    {
        /// <summary>
        /// This will match Major.Minor and optional revision. Major and Minor can be 1-3 digits (0-999)
        /// and Revision can be 6 digits.
        /// https://stackoverflow.com/questions/6618868/regular-expression-for-version-numbers
        /// </summary>
        public const string APPLICATION_VERSION = @"^\d{1,3}\.\d{1,3}(?:\.\d{1,6})?$";

        public const string MOBILE_PHONE_NUMBER = @"^((?:[1-9][0-9 ().-]{3,29}[0-9])|(?:(00|0)( ){0,1}[1-9][0-9 ().-]{3,26}[0-9])|(?:(\+)( ){0,1}[1-9][0-9 ().-]{4,27}[0-9]))$";

        public const string EMAIL_ADDRESS = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public const string ALLOW_NOT_ONLY_WHITE_SPACE = @"\s";
    }
}
