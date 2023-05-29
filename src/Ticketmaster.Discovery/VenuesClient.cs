//   Copyright © 2015-2024 Serhii Voznyi and open source community
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

namespace Ticketmaster.Discovery
{
    using System.Net;
    using System.Threading.Tasks;
    using RestSharp;
    using Ticketmaster.Discovery.Extensions;
    using Ticketmaster.Discovery.Models;

    public class VenuesClient : BaseClient, IVenuesClient
    {
        private readonly string VenuesPath = "/v2/venues.json";
        private readonly string VenuesWithIdPath = "/v2/venues/{id}.json";


        public VenuesClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<SearchVenuesResponse> VenueSearch(SearchVenuesRequest request) =>
            VenueSearch(request, CancellationToken.None);

        public async Task<SearchVenuesResponse> VenueSearch(SearchVenuesRequest request, CancellationToken ct)
        {
            var searchRequest = new RestRequest(VenuesPath) { RequestFormat = DataFormat.Json };
            return await Execute<SearchVenuesResponse>(searchRequest, request, HttpStatusCode.OK, ct);
        }

        public Task<Venue> GetVenueDetails(GetRequest request) => GetVenueDetails(request, CancellationToken.None);

        public async Task<Venue> GetVenueDetails(GetRequest request, CancellationToken ct)
        {
            return await Execute<Venue>(request.ToRestRequest(VenuesWithIdPath), request, HttpStatusCode.OK, ct);
        }
    }
}