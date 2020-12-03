namespace Ticketmaster.Discovery.V2
{
    using System.Threading.Tasks;
    using Core;
    using Core.V2.Models;
    using Models;
    using RestSharp;

    /// <summary>
    ///     The IClassificationsClient Interface.
    /// </summary>
    public interface IClassificationsClient
    {
        /// <summary>
        ///     Searches the classifications asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="SearchClassificationsRequest" /> request.</param>
        /// <returns>The <see cref="SearchClassificationsResponse" />.</returns>
        Task<SearchClassificationsResponse> SearchClassificationsAsync(SearchClassificationsRequest request);

        /// <summary>
        ///     Searches the classifications asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="SearchClassificationsResponse" />.</returns>
        Task<SearchClassificationsResponse> SearchClassificationsAsync(IApiRequest request);

        /// <summary>
        ///     Calls the search classifications asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="SearchClassificationsRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchClassificationsAsync(SearchClassificationsRequest request);

        /// <summary>
        ///     Calls the search classifications asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchClassificationsAsync(IApiRequest request);

        /// <summary>
        ///     Gets the classification details asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" /> with response validation.</returns>
        Task<Classification> GetClassificationDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the classification details asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" /> with response validation.</returns>
        Task<Classification> GetClassificationDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Calls the get classification details asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" />.</returns>
        Task<IRestResponse> CallGetClassificationDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get classification details asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="Classification" />.</returns>
        Task<IRestResponse> CallGetClassificationDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Gets the genre details asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="GetGenreDetailsResponse" /> with response validation.</returns>
        Task<GetGenreDetailsResponse> GetGenreDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the genre details asynchronouslyly.
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
        ///     Gets the sub-genre details asynchronouslyly.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="GetGenreDetailsResponse" /> with response validation.</returns>
        Task<GetGenreDetailsResponse> GetSubGenreDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get sub-segment details method.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>Task result for <see cref="IRestResponse" /> without response validation.</returns>
        Task<IRestResponse> CallGetSubSegmentDetailsAsync(GetRequest request);
    }
}