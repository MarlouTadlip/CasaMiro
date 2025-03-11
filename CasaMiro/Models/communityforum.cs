namespace CasaMiro.Models
{
  
        public class ForumPost
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public DateTime Date { get; set; }
            public List<Comment> Comments { get; set; }
            public bool ShowComments { get; set; }
        }
    public class Comment
    {
        public string Author { get; set; }
        public string Content { get; set; }
    }


}
