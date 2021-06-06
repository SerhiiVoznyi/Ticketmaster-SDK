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

    public class EventsClient : BaseClient, IEventsClient
    {
        public const string EventsPath = "/v2/events.json";
        public const string EventsPathWithId = "/v2/events/{id}.json";
        public const string EventsImagesPath = "/v2/events/{id}/images.json";

        public EventsClient(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<SearchEventsResponse> SearchEventsAsync(SearchEventsRequest request)
        {
            return SearchEventsAsync((IApiRequest)request);
        }

        public Task<SearchEventsResponse> SearchEventsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(EventsPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync<SearchEventsResponse>(searchRequest, HttpStatusCode.OK, request);
        }

        public Task<IRestResponse> CallSearchEventsAsync(SearchEventsRequest request)
        {
            return CallSearchEventsAsync((IApiRequest)request);
        }

        public Task<IRestResponse> CallSearchEventsAsync(IApiRequest request)
        {
            var searchRequest = new RestRequest(EventsPath, Method.GET) { RequestFormat = DataFormat.Json };
            return ExecuteRequestAsync(searchRequest, request);
        }

        public Task<Event> GetEventDetailsAsync(GetRequest request)
        {
            return GetEventDetailsAsync((IApiGetRequest)request);
        }

        public Task<Event> GetEventDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync<Event>(RequestHelper.CreateGetRequest(request, EventsPathWithId),
                HttpStatusCode.OK, request);
        }

        public Task<IRestResponse> CallGetEventDetailsAsync(GetRequest request)
        {
            return CallGetEventDetailsAsync((IApiGetRequest)request);
        }

        public Task<IRestResponse> CallGetEventDetailsAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, EventsPathWithId), request);
        }

        public Task<GetEventImagesResponse> GetEventImagesAsync(GetRequest request)
        {
            return GetEventImagesAsync((IApiGetRequest)request);
        }

        public Task<GetEventImagesResponse> GetEventImagesAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync<GetEventImagesResponse>(
                RequestHelper.CreateGetRequest(request, EventsImagesPath),
                HttpStatusCode.OK, request);
        }

        public Task<IRestResponse> CallGetEventImagesAsync(GetRequest request)
        {
            return CallGetEventImagesAsync((IApiGetRequest)request);
        }

        public Task<IRestResponse> CallGetEventImagesAsync(IApiGetRequest request)
        {
            return ExecuteRequestAsync(RequestHelper.CreateGetRequest(request, EventsImagesPath), request);
        }
    }
}