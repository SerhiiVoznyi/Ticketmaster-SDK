namespace Ticketmaster.Core
{
    public class GetRequest : BaseQuery<GetRequest, string>, IApiGetRequest
    {
        public GetRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public override GetRequest AddQueryParameter<TValue>(string parameterName, TValue value)
        {
            AddParameter(parameterName, value.ToString());
            return this;
        }
    }
}