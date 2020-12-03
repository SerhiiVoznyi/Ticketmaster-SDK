namespace Ticketmaster.Discovery.V2
{
    using System.Threading.Tasks;
    using Core;
    using Core.V2.Models;
    using Models;
    using RestSharp;

    /// <summary>
    ///     The IVenuesClient interface.
    /// </summary>
    public interface IVenuesClient
    {
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
    }
}