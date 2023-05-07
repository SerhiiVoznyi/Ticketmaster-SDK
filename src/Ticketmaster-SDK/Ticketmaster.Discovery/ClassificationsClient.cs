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

using Ticketmaster.Core.Extensions;

namespace Ticketmaster.Discovery
{
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.Models;

    public class ClassificationsClient : BaseClient, IClassificationsClient
    {
        private const string ClassificationsGenresPathWithId = "/v2/classifications/genres/{id}.json";
        private const string ClassificationsPath = "/v2/classifications.json";
        private const string ClassificationsPathWithId = "/v2/classifications/{id}.json";
        private const string ClassificationsSegmentDetailsPathWithId = "/v2/classifications/segments/{id}.json";
        private const string ClassificationsSubGenresPathWithId = "/v2/classifications/subgenres/{id}.json";

        public ClassificationsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<SearchClassificationsResponse> ClassificationSearch(IApiRequest request) =>
            ClassificationSearch(request, CancellationToken.None);

        public async Task<SearchClassificationsResponse> ClassificationSearch(IApiRequest request, CancellationToken ct)
        {
            var searchRequest = new RestRequest(ClassificationsPath) { RequestFormat = DataFormat.Json };
            return await Execute<SearchClassificationsResponse>(searchRequest, request, HttpStatusCode.OK, ct);
        }

        public Task<Classification> GetClassificationDetails(GetRequest request) => GetClassificationDetails(request, CancellationToken.None);

        public async Task<Classification> GetClassificationDetails(GetRequest request, CancellationToken ct)
        {
            return await Execute<Classification>(request.ToRestRequest(ClassificationsPathWithId), request, HttpStatusCode.OK, ct);
        }

        public Task<GetGenreDetailsResponse> GetGenreDetails(GetRequest request) => GetGenreDetails(request, CancellationToken.None);

        public async Task<GetGenreDetailsResponse> GetGenreDetails(GetRequest request, CancellationToken ct)
        {
            return await Execute<GetGenreDetailsResponse>(request.ToRestRequest(ClassificationsGenresPathWithId), request, HttpStatusCode.OK, ct);
        }

        public Task<GetGenreDetailsResponse> GetSegmentDetails(GetRequest request) => GetGenreDetails(request, CancellationToken.None);

        public async Task<GetGenreDetailsResponse> GetSegmentDetails(GetRequest request, CancellationToken ct)
        {
            return await Execute<GetGenreDetailsResponse>(request.ToRestRequest(ClassificationsSegmentDetailsPathWithId), request, HttpStatusCode.OK, ct);
        }

        public Task<GetGenreDetailsResponse> GetSubGenreDetails(GetRequest request) => GetSubGenreDetails(request, CancellationToken.None);

        public async Task<GetGenreDetailsResponse> GetSubGenreDetails(GetRequest request, CancellationToken ct)
        {
            return await Execute<GetGenreDetailsResponse>(request.ToRestRequest(ClassificationsSubGenresPathWithId), request, HttpStatusCode.OK, ct);
        }
    }
}