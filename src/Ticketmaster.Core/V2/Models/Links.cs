namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;

    public class Links
    {
        public Links()
        {
            Venues = new List<Link>();
        }

        public Link First { get; set; }
        public Link Self { get; set; }
        public Link Next { get; set; }
        public Link Last { get; set; }
        public List<Link> Venues { get; set; }
    }
}