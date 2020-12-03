namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;
    public class Segment : IdNamePair
    {
        public Links Links { get; set; }
        public Embedded _embedded { get; set; }
        public class Embedded
        {
            public Embedded()
            {
                Genres = new List<Genre>();
            }

            public List<Genre> Genres { get; set; }
        }
    }
}