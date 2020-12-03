namespace Ticketmaster.Core.V2.Models
{
    public class PriceRange : MinMaxPair
    {
        public string Type { get; set; }
        public string Currency { get; set; }
    }
}