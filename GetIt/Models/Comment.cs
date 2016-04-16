using System;
using System.ComponentModel.DataAnnotations;

namespace GetIt.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Post Post { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
    }
}