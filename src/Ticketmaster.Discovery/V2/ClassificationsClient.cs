//   Copyright © 2015-2021 Serhii Voznyi and open source community
//
//     https://www.linkedin.com/in/serhii-voznyi/
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
namespace Ticketmaster.Discovery.V2
{
    using Core;
    using Core.V2.Models;
    using Models;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;

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
            return SearchClassificationsAsync((IApiRequest)request);
        }

        public Task<SearchClassificationsResponse> SearchClassificationsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(ClassificationsPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync<SearchClassificationsResponse>(searchRequest, HttpStatusCode.OK, request);
        }

        public Task<IRestResponse> CallSearchClassificationsAsync(SearchClassificationsRequest request)
        {
            return CallSearchClassificationsAsync((IApiRequest)request);
        }

        public Task<IRestResponse> CallSearchClassificationsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(ClassificationsPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync(searchRequest, request);
        }

        public Task<Classification> GetClassificationDetailsAsync(GetRequest request)
        {
            return GetClassificationDetailsAsync((IApiGetRequest)request);
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
            return CallGetClassificationDetailsAsync((IApiGetRequest)request);
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