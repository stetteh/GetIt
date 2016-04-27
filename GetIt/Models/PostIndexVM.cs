using System;
using Humanizer;

namespace GetIt.Models
{
    public class PostIndexVM
    {
        public int Votes { get; set; }
        public string Title { get; set; }
        public int PostId { get; set; }
        public DateTime SubmitDate { get; set; }
        public string AuthorName { get; set; }
        public int CommentCount { get; set; }
        public string PrettyDate => SubmitDate.Humanize();

    }

    public class CommentVM
    {
        public int CommentId { get; set; }
        public int Votes { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public DateTime SubmitDate { get; set; }
        public string PrettyDate => SubmitDate.Humanize();
    }
}

