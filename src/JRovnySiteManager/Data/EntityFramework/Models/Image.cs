using System.ComponentModel.DataAnnotations.Schema;

namespace JRovnySiteManager.Data.EntityFramework.Models
{
    [Table("image")]
    public class Image
    {
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
    }
}