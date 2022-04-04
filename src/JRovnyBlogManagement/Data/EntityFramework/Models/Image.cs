using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JRovny.BlogManagement.Data.EntityFramework.Models
{
    [Table("image")]
    public class Image
    {
        public Image()
        {
            Posts = new List<Post>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("image_id")]
        public int ImageId { get; set; }
        [Column("file_name")]
        public string FileName { get; set; }
        [Column("original_file_name")]
        public string OriginalFileName { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("alt_name")]
        public string AltName { get; set; }
        [Column("url")]
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}