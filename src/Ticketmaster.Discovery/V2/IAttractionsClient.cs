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
    ///     The IAttractionsClient interface.
    /// </summary>
    public interface IAttractionsClient
    {
        /// <summary>
        ///     Searches the attractions asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchAttractionsRequest" /> request.</param>
        /// <returns>The <see cref="SearchAttractionsResponse" />.</returns>
        Task<SearchAttractionsResponse> SearchAttractionsAsync(SearchAttractionsRequest request);

        /// <summary>
        ///     Searches the attractions asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="SearchAttractionsResponse" />.</returns>
        Task<SearchAttractionsResponse> SearchAttractionsAsync(IApiRequest request);

        /// <summary>
        ///     Calls the search attractions asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="SearchAttractionsRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchAttractionsAsync(SearchAttractionsRequest request);

        /// <summary>
        ///     Calls the search attractions asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchAttractionsAsync(IApiRequest request);

        /// <summary>
        ///     Gets the attraction details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="Attraction" />.</returns>
        Task<Attraction> GetAttractionDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the attraction details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="Attraction" />.</returns>
        Task<Attraction> GetAttractionDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Calls the get attraction details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetAttractionDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get attraction details asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetAttractionDetailsAsync(IApiGetRequest request);
    }
}