namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;

    public class Event : BaseEvent, IApiResponse
    {
        public Event()
        {
            PriceRanges = new List<PriceRange>();
            Products = new List<Product>();
            Classifications = new List<Classification>();
        }

        public string Description { get; set; }
        public Dates Dates { get; set; }
        public Sales Sales { get; set; }
        public Links Links { get; set; }
        public Embedded _embedded { get; set; }
        public Promoter Promoter { get; set; }
        public Seatmap Seatmap { get; set; }
        public List<Classification> Classifications { get; set; }
        public List<PriceRange> PriceRanges { get; set; }
        public List<Product> Products { get; set; }

        public class Embedded
        {
            public Embedded()
            {
                Venues = new List<Venue>();
            }

            public List<Venue> Venues { get; set; }
        }
    }
}