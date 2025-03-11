namespace CasaMiro.Models
{
    public class AnalyticsReport
    {
        public int TotalUsers { get; set; }
        public int TotalFeedbacks { get; set; }
        public int TotalComplaints { get; set; }
        public int TotalEvents { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
