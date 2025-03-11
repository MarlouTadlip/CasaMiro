namespace CasaMiro.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public bool IsComplaint { get; set; }
    }
}
