namespace CasaMiro.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CreatedById { get; set; } // Links to User.Id
        public User? CreatedBy { get; set; } // Navigation property
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}