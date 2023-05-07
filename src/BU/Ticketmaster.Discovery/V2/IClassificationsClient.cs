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
    ///     The IClassificationsClient Interface.
    /// </summary>
    public interface IClassificationsClient
    {
        /// <summary>
        ///     Gets the classification details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" /> with response validation.</returns>
        Task<Classification> GetClassificationDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the classification details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" /> with response validation.</returns>
        Task<Classification> GetClassificationDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Gets the genre details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="GetGenreDetailsResponse" /> with response validation.</returns>
        Task<GetGenreDetailsResponse> GetGenreDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the sub-genre details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="GetGenreDetailsResponse" /> with response validation.</returns>
        Task<GetGenreDetailsResponse> GetSubGenreDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get classification details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" />.</returns>
        Task<IRestResponse> CallGetClassificationDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get classification details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" />.</returns>
        Task<IRestResponse> CallGetClassificationDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Gets the genre details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetGenreDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get segment details method.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="IRestResponse" /> without response validation.</returns>
        Task<IRestResponse> CallGetSegmentDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get sub-segment details method.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="IRestResponse" /> without response validation.</returns>
        Task<IRestResponse> CallGetSubSegmentDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the search classifications asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchClassificationsRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchClassificationsAsync(SearchClassificationsRequest request);

        /// <summary>
        ///     Calls the search classifications asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchClassificationsAsync(IApiRequest request);

        /// <summary>
        ///     Searches the classifications asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchClassificationsRequest" /> request.</param>
        /// <returns>The <see cref="SearchClassificationsResponse" />.</returns>
        Task<SearchClassificationsResponse> SearchClassificationsAsync(SearchClassificationsRequest request);

        /// <summary>
        ///     Searches the classifications asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="SearchClassificationsResponse" />.</returns>
        Task<SearchClassificationsResponse> SearchClassificationsAsync(IApiRequest request);
    }
}