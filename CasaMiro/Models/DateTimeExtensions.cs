namespace CasaMiro.Models
{
    // Extension methods for DateTime should be in a static class
    public static class DateTimeExtensions
    {
        // Get the start of the week (Sunday) for a given DateTime
        public static DateTime StartOfWeek(this DateTime date)
        {
            int diff = date.DayOfWeek - DayOfWeek.Sunday;
            if (diff < 0)
            {
                diff += 7;
            }
            return date.AddDays(-diff).Date;
        }
    }
}
