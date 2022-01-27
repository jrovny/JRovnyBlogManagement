using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRovnySiteManager.Data.EntityFramework.Models
{
    [Table("post")]
    public class Post
    {
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("slug")]
        public string Slug { get; set; }
        [Column("published")]
        public bool Published { get; set; }
        [Column("published_date")]
        public DateTime? PublishedDate { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}