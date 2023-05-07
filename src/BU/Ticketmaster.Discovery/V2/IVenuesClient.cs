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
    using System.Threading.Tasks;

    /// <summary>
    ///     The IVenuesClient interface.
    /// </summary>
    public interface IVenuesClient
    {
        /// <summary>
        ///     Calls the get venue details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The Task <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetVenueDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get venue details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The Task <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetVenueDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Calls the get search venues.
        /// </summary>
        /// <param name="query">The <see cref="SearchVenuesRequest" /> query.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchVenuesAsync(SearchVenuesRequest query);

        /// <summary>
        ///     Calls the get search venues.
        /// </summary>
        /// <param name="query">The <see cref="IApiRequest" /> query.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchVenuesAsync(IApiRequest query);

        /// <summary>
        ///     Gets the search venues.
        /// </summary>
        /// <param name="query">The <see cref="SearchVenuesRequest" /> query.</param>
        /// <returns>The <see cref="SearchEventsResponse" />.</returns>
        Task<SearchVenuesResponse> SearchVenuesAsync(SearchVenuesRequest query);

        /// <summary>
        ///     Gets the search venues.
        /// </summary>
        /// <param name="query">The <see cref="IApiRequest" /> query.</param>
        /// <returns>The <see cref="SearchEventsResponse" />.</returns>
        Task<SearchVenuesResponse> SearchVenuesAsync(IApiRequest query);


        /// <summary>
        ///     Gets the venue details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The Task <see cref="Venue" />.</returns>
        Task<Venue> GetVenueDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the venue details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The Task <see cref="Venue" />.</returns>
        Task<Venue> GetVenueDetailsAsync(IApiGetRequest request);
    }
}