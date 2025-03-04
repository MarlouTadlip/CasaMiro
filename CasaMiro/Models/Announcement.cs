namespace CasaMiro.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
