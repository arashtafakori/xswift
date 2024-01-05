namespace XSwift.Base
{
    /// <summary>
    /// Helper class providing utility methods for working with date and time.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Gets the current Coordinated Universal Time (UTC) date and time.
        /// </summary>
        public static DateTime UtcNow {
            get 
            {
                // Returns the current UTC date and time.
                return DateTimeOffset.UtcNow.DateTime;
            }
        }
    }
}
