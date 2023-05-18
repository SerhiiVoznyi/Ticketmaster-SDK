﻿//   Copyright © 2015-2023 Serhii Voznyi and open source community
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
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.Models;

    public interface IVenuesClient
    {
        public Task<SearchVenuesResponse> VenueSearch(SearchVenuesRequest request);

        public Task<SearchVenuesResponse> VenueSearch(SearchVenuesRequest request, CancellationToken ct);

        public Task<Venue> GetVenueDetails(GetRequest request);

        public Task<Venue> GetVenueDetails(GetRequest request, CancellationToken ct);
    }
}