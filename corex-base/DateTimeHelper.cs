namespace CoreX.Base
{
    public static class DateTimeHelper
    {
        public static DateTime Now {
            get 
            {
                return DateTimeOffset.UtcNow.DateTime;
            }
        }
    }
}
