namespace Ticketmaster.Discovery.V2.Models
{
    using Core;
    using Core.V2.Models;

    public class SearchClassificationsRequest : BaseQuery<SearchClassificationsRequest, QueryParameters>
    {
        public override SearchClassificationsRequest AddQueryParameter<TValue>(QueryParameters parameter, TValue value)
        {
            AddParameter(parameter, value);
            return this;
        }
    }
}