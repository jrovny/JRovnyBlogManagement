using System;

namespace JRovny.BlogManagement.Models
{
    public class PostSummary
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}