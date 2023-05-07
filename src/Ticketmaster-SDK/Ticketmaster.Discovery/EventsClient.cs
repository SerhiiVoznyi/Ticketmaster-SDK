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

using RestSharp;
using System.Net;
using Ticketmaster.Core;
using Ticketmaster.Core.Extensions;
using Ticketmaster.Core.V2.Models;
using Ticketmaster.Discovery.Models;

namespace Ticketmaster.Discovery
{

    public class EventsClient : BaseClient, IEventsClient
    {
        public const string EventsImagesPath = "/v2/events/{id}/images.json";
        public const string EventsPath = "/v2/events.json";
        public const string EventsPathWithId = "/v2/events/{id}.json";

        public EventsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<SearchEventsResponse> EventSearch(SearchEventsRequest request) =>
            EventSearch(request, CancellationToken.None);

        public async Task<SearchEventsResponse> EventSearch(SearchEventsRequest request, CancellationToken ct)
        {
            var searchRequest = new RestRequest(EventsPath) { RequestFormat = DataFormat.Json };
            return await Execute<SearchEventsResponse>(searchRequest, request, HttpStatusCode.OK, ct);
        }

        public Task<Event> GetEventDetails(GetRequest request) =>
            GetEventDetails(request, CancellationToken.None);

        public async Task<Event> GetEventDetails(GetRequest request, CancellationToken ct) =>
            await Execute<Event>(request.ToRestRequest(EventsPathWithId), request, HttpStatusCode.OK, ct);

        public Task<GetEventImagesResponse> GetImages(GetRequest request) =>
            GetImages(request, CancellationToken.None);

        public async Task<GetEventImagesResponse> GetImages(GetRequest request, CancellationToken ct) =>
            await Execute<GetEventImagesResponse>(request.ToRestRequest(EventsImagesPath), request, HttpStatusCode.OK, ct);
    }
}