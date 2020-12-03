namespace Ticketmaster.Core.V2.Models
{
    using System;

    public class Start
    {
        public string LocalDate { get; set; }
        public string LocalTime { get; set; }
        public DateTime DateTime { get; set; }
        public bool DateTbd { get; set; }
        public bool DateTba { get; set; }
        public bool TimeTba { get; set; }
        public bool NoSpecificTime { get; set; }
    }
}