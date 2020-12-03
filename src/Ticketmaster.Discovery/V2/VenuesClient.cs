namespace Ticketmaster.Discovery.V2
{
    using System.Net;
    using System.Threading.Tasks;
    using Core;
    using Core.V2.Models;
    using Models;
    using RestSharp;

    public class VenuesClient : BaseClient, IVenuesClient
    {
        private readonly string VenuesPath = "/v2/venues.json";
        private readonly string VenuesWithIdPath = "/v2/venues/{id}.json";


        public VenuesClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<SearchVenuesResponse> SearchVenuesAsync(SearchVenuesRequest query)
        {
            return SearchVenuesAsync((IApiRequest) query);
        }

        public Task<SearchVenuesResponse> SearchVenuesAsync(IApiRequest query)
        {
            var searchRequest = new RestRequest(VenuesPath, Method.GET) {RequestFormat = DataFormat.Json};
            return ExecuteRequestAsync<SearchVenuesResponse>(searchRequest, HttpStatusCode.OK, query);
        }

        public Task<IRestResponse> CallSearchVenuesAsync(SearchVenuesRequest query)
        {
            return CallSearchVenuesAsync((IApiRequest) query);
        }

        public Task<IRestResponse> CallSearchVenuesAsync(IApiRequest query)
        {
            var searchRequest = new RestRequest(VenuesWithIdPath, Method.GET) {RequestFormat = DataFormat.Json};
            return ExecuteRequestAsync(searchRequest, query);
        }

        public Task<Venue> GetVenueDetailsAsync(GetRequest request)
        {
            return GetVenueDetailsAsync((IApiGetRequest) request);
        }

        public Task<Venue> GetVenueDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync<Venue>(RequestHelper.CreateGetRequest(request, VenuesWithIdPath),
                HttpStatusCode.OK, request);
        }

        public Task<IRestResponse> CallGetVenueDetailsAsync(GetRequest request)
        {
            return CallGetVenueDetailsAsync((IApiGetRequest) request);
        }

        public Task<IRestResponse> CallGetVenueDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, VenuesWithIdPath), request);
        }
    }
}