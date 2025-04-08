namespace CasaMiro.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted_At { get; set; }
        public string Category { get; set; }
    }
}
