namespace Ticketmaster.Discovery.V2
{
    using System.Net;
    using System.Threading.Tasks;
    using Core;
    using Core.V2.Models;
    using Models;
    using RestSharp;

    public class ClassificationsClient : BaseClient, IClassificationsClient
    {
        private const string ClassificationsPath = "/v2/classifications.json";
        private const string ClassificationsPathWithId = "/v2/classifications/{id}.json";
        private const string ClassificationsGenresPathWithId = "/v2/classifications/genres/{id}.json";
        private const string ClassificationsSubGenresPathWithId = "/v2/classifications/subgenres/{id}.json";
        private const string ClassificationsSegmentDetailsPathWithId = "/v2/classifications/segments/{id}.json";

        public ClassificationsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<SearchClassificationsResponse> SearchClassificationsAsync(SearchClassificationsRequest request)
        {
            return SearchClassificationsAsync((IApiRequest) request);
        }

        public Task<SearchClassificationsResponse> SearchClassificationsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(ClassificationsPath, Method.GET) {RequestFormat = DataFormat.Json};
            return ExecuteRequestAsync<SearchClassificationsResponse>(searchRequest, HttpStatusCode.OK, request);
        }

        public Task<IRestResponse> CallSearchClassificationsAsync(SearchClassificationsRequest request)
        {
            return CallSearchClassificationsAsync((IApiRequest) request);
        }

        public Task<IRestResponse> CallSearchClassificationsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(ClassificationsPath, Method.GET) {RequestFormat = DataFormat.Json};
            return ExecuteRequestAsync(searchRequest, request);
        }

        public Task<Classification> GetClassificationDetailsAsync(GetRequest request)
        {
            return GetClassificationDetailsAsync((IApiGetRequest) request);
        }

        public Task<Classification> GetClassificationDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync<Classification>(
                RequestHelper.CreateGetRequest(request, ClassificationsPathWithId),
                HttpStatusCode.OK,
                request);
        }

        public Task<IRestResponse> CallGetClassificationDetailsAsync(GetRequest request)
        {
            return CallGetClassificationDetailsAsync((IApiGetRequest) request);
        }

        public Task<IRestResponse> CallGetClassificationDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync(
                RequestHelper.CreateGetRequest(request, ClassificationsPathWithId),
                request);
        }

        public Task<GetGenreDetailsResponse> GetGenreDetailsAsync(GetRequest request)
        {
            return ExecuteRequestAsync<GetGenreDetailsResponse>(
                RequestHelper.CreateGetRequest(request, ClassificationsGenresPathWithId),
                HttpStatusCode.OK,
                request);
        }

        public Task<IRestResponse> CallGetGenreDetailsAsync(GetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, ClassificationsGenresPathWithId),
                request);
        }

        public Task<GetGenreDetailsResponse> GetSubGenreDetailsAsync(GetRequest request)
        {
            return ExecuteRequestAsync<GetGenreDetailsResponse>(
                RequestHelper.CreateGetRequest(request, ClassificationsSubGenresPathWithId),
                HttpStatusCode.OK,
                request);
        }

        public Task<IRestResponse> CallGetSegmentDetailsAsync(GetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, ClassificationsSegmentDetailsPathWithId),
                request);
        }

        public Task<IRestResponse> CallGetSubSegmentDetailsAsync(GetRequest request)
        {
            return ExecuteRequestAsync(
                RequestHelper.CreateGetRequest(request, ClassificationsSubGenresPathWithId),
                request);
        }
    }
}