namespace Ticketmaster.Discovery.V2.Models
{
    using Core;

    public class SearchVenuesRequest : BaseQuery<SearchVenuesRequest, SearchVenuesQueryParameters>
    {
        public override SearchVenuesRequest AddQueryParameter<TValue>(SearchVenuesQueryParameters parameter, TValue value)
        {
            AddParameter(parameter, value);
            return this;
        }
    }
}