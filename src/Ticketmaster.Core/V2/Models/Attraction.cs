namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;

    public class Attraction : BaseEvent, IApiResponse
    {
        public Attraction()
        {
            Classifications = new List<Classification>();
        }


        public List<Classification> Classifications { get; set; }

        public Links Links { get; set; }
    }
}