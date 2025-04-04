namespace CasaMiro.Models
{
    public class UserForumPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public string Author { get; set; } // Author's name
        public List<ForumReply> Replies { get; set; } = new List<ForumReply>();
    }

    public class ForumReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime ReplyDate { get; set; }
        public string Author { get; set; } // Author's name
    }
}
