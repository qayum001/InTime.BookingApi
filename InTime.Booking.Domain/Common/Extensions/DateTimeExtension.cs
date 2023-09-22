namespace InTime.Booking.Domain.Common.Extension
{
    public static class DateTimeExtension
    {
        public static int GetDayInSeconds(this DateTime dateTime)
        {
            var res = (dateTime.Hour * 60 * 60) + (dateTime.Minute * 60);
            return res;
        }
    }
}
