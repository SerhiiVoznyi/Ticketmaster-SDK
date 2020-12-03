namespace Ticketmaster.Core.V2.Models
{
    public class Image
    {
        public string Ratio { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Fallback { get; set; }
    }
}