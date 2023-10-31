namespace XSwift.Base
{
    public static class DateTimeHelper
    {
        public static DateTime UtcNow {
            get 
            {
                return DateTimeOffset.UtcNow.DateTime;
            }
        }
    }
}
