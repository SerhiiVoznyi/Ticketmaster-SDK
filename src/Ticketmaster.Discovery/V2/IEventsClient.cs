namespace Ticketmaster.Discovery.V2
{
    using System.Threading.Tasks;
    using Core;
    using Core.V2.Models;
    using Models;
    using RestSharp;

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