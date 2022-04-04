using System;

namespace JRovny.BlogManagement.Models
{
    public class PostDetailView
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}