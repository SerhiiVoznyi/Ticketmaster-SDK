//   Copyright © 2015-2023 Serhii Voznyi and open source community
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
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.V2.Models;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;

    public class AttractionsClient : BaseClient, IAttractionsClient
    {
        private const string AttractionsPath = "/v2/attractions.json";
        private const string AttractionsWithIdPath = "/v2/attractions/{id}.json";

        public AttractionsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<IRestResponse> CallGetAttractionDetailsAsync(GetRequest request)
        {
            return CallGetAttractionDetailsAsync((IApiGetRequest)request);
        }

        public Task<IRestResponse> CallGetAttractionDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, AttractionsWithIdPath), request);
        }

        public Task<IRestResponse> CallSearchAttractionsAsync(SearchAttractionsRequest request)
        {
            return CallSearchAttractionsAsync((IApiRequest)request);
        }

        public Task<IRestResponse> CallSearchAttractionsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(AttractionsPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync(searchRequest, request);
        }

        public Task<Attraction> GetAttractionDetailsAsync(GetRequest request)
        {
            return GetAttractionDetailsAsync((IApiGetRequest)request);
        }

        public Task<Attraction> GetAttractionDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync<Attraction>(RequestHelper.CreateGetRequest(request, AttractionsWithIdPath),
                HttpStatusCode.OK, request);
        }

        public Task<SearchAttractionsResponse> SearchAttractionsAsync(SearchAttractionsRequest request)
        {
            return SearchAttractionsAsync((IApiRequest)request);
        }

        public Task<SearchAttractionsResponse> SearchAttractionsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(AttractionsPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync<SearchAttractionsResponse>(searchRequest, HttpStatusCode.OK, request);
        }
    }
}