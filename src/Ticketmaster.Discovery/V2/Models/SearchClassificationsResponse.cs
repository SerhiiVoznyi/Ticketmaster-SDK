namespace Ticketmaster.Discovery.V2.Models
{
    using System.Collections.Generic;
    using Core;
    using Core.V2.Models;

    public class SearchClassificationsResponse : IApiResponse
    {
        public Embedded _embedded { get; set; }

        public Links Links { get; set; }
        public Page Page { get; set; }

        public class Embedded
        {
            public Embedded()
            {
                Classifications = new List<Classification>();
            }

            public List<Classification> Classifications { get; set; }
        }
    }
}