﻿//   Copyright © 2015-2024 Serhii Voznyi and open source community
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
    using System.Threading.Tasks;
    using Ticketmaster.Discovery.Models;

    public interface IEventsClient
    {
        Task<Event> GetDetails(GetRequest request);
        Task<Event> GetDetails(GetRequest request, CancellationToken ct);

        Task<GetEventImagesResponse> GetImages(GetRequest request);
        Task<GetEventImagesResponse> GetImages(GetRequest request, CancellationToken ct);

        Task<SearchEventsResponse> Search(SearchEventsRequest request);
        Task<SearchEventsResponse> Search(SearchEventsRequest request, CancellationToken ct);
    }
}