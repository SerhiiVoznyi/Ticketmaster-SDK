namespace Ticketmaster.Core.V2.Models
{
    using System.Collections.Generic;

    public class BaseEvent : IdNamePair
    {
        public BaseEvent()
        {
            Images = new List<Image>();
        }

        public string Type { get; set; }
        public bool Test { get; set; }
        public string Url { get; set; }
        public string Locale { get; set; }
        public string Info { get; set; }
        public List<Image> Images { get; set; }
    }
}