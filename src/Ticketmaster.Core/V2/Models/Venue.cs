namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;

    public class Venue : BaseEvent, IApiResponse
    {
        public Venue()
        {
            Markets = new List<Market>();
        }

        public string Timezone { get; set; }
        public string PostalCode { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public Address Address { get; set; }
        public Location Location { get; set; }
        public Links Links { get; set; }
        public List<Market> Markets { get; set; }
    }
}