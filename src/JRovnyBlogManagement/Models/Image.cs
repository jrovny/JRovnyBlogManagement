namespace JRovny.BlogManagement.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public bool Active { get; set; }
        public string AltName { get; set; }
        public string Url { get; set; }
    }
}