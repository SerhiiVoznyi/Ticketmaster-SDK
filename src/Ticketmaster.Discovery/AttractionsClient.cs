//   Copyright © 2015-2026 Serhii Voznyi and open source community
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

    public class AttractionsClient : BaseClient, IAttractionsClient
    {
        private const string AttractionsPath = "/v2/attractions.json";
        private const string AttractionsWithIdPath = "/v2/attractions/{id}.json";

        public AttractionsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<Attraction> GetDetails(GetRequest request) =>
            GetDetails(request, CancellationToken.None);

        public async Task<Attraction> GetDetails(GetRequest request, CancellationToken ct)
        {
            return await Execute<Attraction>(request.ToRestRequest(AttractionsWithIdPath), request, HttpStatusCode.OK, ct);
        }

        public Task<SearchAttractionsResponse> Search(SearchAttractionsRequest request) =>
            Search(request, CancellationToken.None);

        public Task<SearchAttractionsResponse> Search(SearchAttractionsRequest request, CancellationToken ct)
        {
            var searchRequest = new RestRequest(AttractionsPath) { RequestFormat = DataFormat.Json };
            return Execute<SearchAttractionsResponse>(searchRequest, request, HttpStatusCode.OK, ct);
        }
    }
}