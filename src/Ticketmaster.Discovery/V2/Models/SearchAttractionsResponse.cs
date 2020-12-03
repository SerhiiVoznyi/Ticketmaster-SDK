namespace Ticketmaster.Discovery.V2.Models
{
    using System.Collections.Generic;
    using Core;
    using Core.V2.Models;

    public class SearchAttractionsResponse : IApiResponse
    {
        public Embedded _embedded { get; set; }

        public Links Links { get; set; }

        public Page Page { get; set; }

        public class Embedded
        {
            public Embedded()
            {
                Attractions = new List<Attraction>();
            }

            public List<Attraction> Attractions { get; set; }
        }
    }
}