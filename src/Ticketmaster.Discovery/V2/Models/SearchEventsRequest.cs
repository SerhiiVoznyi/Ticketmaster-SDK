namespace Ticketmaster.Discovery.V2.Models
{
    using Core;

    public class SearchEventsRequest : BaseQuery<SearchEventsRequest, SearchEventsQueryParameters>
    {


        public override SearchEventsRequest AddQueryParameter<TValue>(SearchEventsQueryParameters parameter, TValue value)
        {
            AddParameter(parameter, value);
            return this;
        }
    }
}