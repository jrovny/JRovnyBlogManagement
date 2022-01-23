using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRovnySiteManager.Models
{
    [Table("post")]
    public class Post
    {
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("slug")]
        public string Slug { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}