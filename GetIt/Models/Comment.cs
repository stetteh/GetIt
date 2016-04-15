using System;

namespace GetIt.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
    }
}