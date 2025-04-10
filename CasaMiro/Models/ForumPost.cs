// Models/ForumPost.cs
using System;
using System.Collections.Generic;

namespace CasaMiro.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime Date { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public bool ShowComments { get; set; }
        public List<Reply> Replies { get; set; } = new List<Reply>(); // Add this line
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; } = "";
        public string Content { get; set; } = "";
        public int ForumPostId { get; set; }
    }

    public class Reply
    {
        public int Id { get; set; }
        public string Author { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime Date { get; set; }
        public int ForumPostId { get; set; }
    }
}
