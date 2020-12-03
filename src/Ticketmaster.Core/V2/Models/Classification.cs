namespace Ticketmaster.Core.V2.Models
{
    public class Classification : IApiResponse
    {
        public bool Primary { get; set; }
        public Segment Segment { get; set; }
        public Genre Genre { get; set; }
        public SubGenre SubGenre { get; set; }
        public Links Links { get; set; }
    }
}