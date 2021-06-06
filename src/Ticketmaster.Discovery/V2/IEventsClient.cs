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
    using System.Threading.Tasks;

    /// <summary>
    ///     The IEventsClient interface.
    /// </summary>
    public interface IEventsClient
    {
        /// <summary>
        ///     Searches the events asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchEventsRequest" /> request.</param>
        /// <returns>The task for <see cref="SearchEventsResponse" />.</returns>
        Task<SearchEventsResponse> SearchEventsAsync(SearchEventsRequest request);

        /// <summary>
        ///     Searches the events asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The task for <see cref="SearchEventsResponse" />.</returns>
        Task<SearchEventsResponse> SearchEventsAsync(IApiRequest request);

        /// <summary>
        ///     Calls the search events asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchEventsRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchEventsAsync(SearchEventsRequest request);

        /// <summary>
        ///     Calls the search events asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchEventsAsync(IApiRequest request);

        /// <summary>
        ///     Gets the event details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" />.</param>
        /// <returns>The task for <see cref="Event" />.</returns>
        Task<Event> GetEventDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the event details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" />.</param>
        /// <returns>The task for <see cref="Event" />.</returns>
        Task<Event> GetEventDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Calls the get event details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The Task <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetEventDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get event details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The Task <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetEventDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Gets the event images asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" />.</param>
        /// <returns>The Task for <see cref="GetEventImagesResponse" />.</returns>
        Task<GetEventImagesResponse> GetEventImagesAsync(GetRequest request);

        /// <summary>
        ///     Gets the event images asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" />.</param>
        /// <returns>The Task for <see cref="GetEventImagesResponse" />.</returns>
        Task<GetEventImagesResponse> GetEventImagesAsync(IApiGetRequest request);

        /// <summary>
        ///     Calls the get event images asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The Task for <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetEventImagesAsync(GetRequest request);

        /// <summary>
        ///     Calls the get event images asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The Task for <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetEventImagesAsync(IApiGetRequest request);
    }
}