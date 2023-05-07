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

    public class VenuesClient : BaseClient, IVenuesClient
    {
        private readonly string VenuesPath = "/v2/venues.json";
        private readonly string VenuesWithIdPath = "/v2/venues/{id}.json";


        public VenuesClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<IRestResponse> CallGetVenueDetailsAsync(GetRequest request)
        {
            return CallGetVenueDetailsAsync((IApiGetRequest)request);
        }

        public Task<IRestResponse> CallGetVenueDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, VenuesWithIdPath), request);
        }

        public Task<IRestResponse> CallSearchVenuesAsync(SearchVenuesRequest query)
        {
            return CallSearchVenuesAsync((IApiRequest)query);
        }

        public Task<IRestResponse> CallSearchVenuesAsync(IApiRequest query)
        {
            var searchRequest = new RestRequest(VenuesWithIdPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync(searchRequest, query);
        }

        public Task<Venue> GetVenueDetailsAsync(GetRequest request)
        {
            return GetVenueDetailsAsync((IApiGetRequest)request);
        }

        public Task<Venue> GetVenueDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync<Venue>(RequestHelper.CreateGetRequest(request, VenuesWithIdPath),
                HttpStatusCode.OK, request);
        }

        public Task<SearchVenuesResponse> SearchVenuesAsync(SearchVenuesRequest query)
        {
            return SearchVenuesAsync((IApiRequest)query);
        }

        public Task<SearchVenuesResponse> SearchVenuesAsync(IApiRequest query)
        {
            var searchRequest = new RestRequest(VenuesPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync<SearchVenuesResponse>(searchRequest, HttpStatusCode.OK, query);
        }
    }
}