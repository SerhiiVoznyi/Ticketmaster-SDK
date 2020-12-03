namespace Ticketmaster.Discovery.Tests.V2.Extensions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.V2;
    using Ticketmaster.Discovery.V2.Models;

    public static class EventsClientExtensions
    {
        public static async Task<SearchEventsResponse> AggregateSearchResultsAsync(
            this IEventsClient client,
            SearchEventsRequest originalRequest
            )
        {
            var aggregatedEvents = new List<Event>();

            var result = await client.SearchEventsAsync(originalRequest);
            aggregatedEvents.AddRange(result._embedded.Events);
            while (result.Page.Number < result.Page.TotalPages)
            {
                originalRequest.NextPage(result);
                await Task.Delay(ApiConstraints.RequiredRequestDelay);
                result = await client.SearchEventsAsync(originalRequest);
                aggregatedEvents.AddRange(result._embedded.Events);
            }

            result._embedded.Events = aggregatedEvents;
            return result;
        }

        private static void NextPage(this SearchEventsRequest originalRequest, SearchEventsResponse response)
        {
            const int pageIncrement = 1;

            if (response.Page.Number >= response.Page.TotalPages)
            {
                return;
            }

            var pageNumber = response.Page.Number + pageIncrement;
            originalRequest.AddQueryParameter(SearchEventsQueryParameters.page, pageNumber);

            if (response.Page.Size * pageNumber < ApiConstraints.MaxPagingDepth)
            {
                return;
            }

            var pageSize = response.Page.Size;
            while (pageSize * pageNumber >= ApiConstraints.MaxPagingDepth)
            {
                pageSize--;
            }

            originalRequest.AddQueryParameter(SearchEventsQueryParameters.size,
                pageSize > ApiConstraints.MinPageSize
                    ? pageSize
                    : ApiConstraints.MinPageSize);
        }
    }
}
