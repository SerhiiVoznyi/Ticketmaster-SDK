namespace Ticketmaster.Discovery.V2.Models
{
    using Core;
    using Core.V2.Models;

    public class SearchAttractionsRequest : BaseQuery<SearchAttractionsRequest, QueryParameters>
    {
        public override SearchAttractionsRequest AddQueryParameter<TValue>(QueryParameters parameter, TValue value)
        {
            AddParameter(parameter, value);
            return this;
        }
    }
}