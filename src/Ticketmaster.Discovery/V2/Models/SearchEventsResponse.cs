namespace Ticketmaster.Discovery.V2.Models
{
    using Core;
    using Core.V2.Models;
    using System.Collections.Generic;

    public class SearchEventsResponse : ApiResponseBase<SearchEventsResponse.Embedded>
    {
        public class Embedded
        {
            public Embedded()
            {
                Events = new List<Event>();
            }

            public List<Event> Events { get; set; }
        }
    }
}