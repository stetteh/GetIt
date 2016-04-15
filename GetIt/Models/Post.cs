using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GetIt.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostDate { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}