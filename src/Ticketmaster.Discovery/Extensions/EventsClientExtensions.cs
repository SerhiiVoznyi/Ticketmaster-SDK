using System.Collections.ObjectModel;
using Ticketmaster.Discovery.Models;

namespace Ticketmaster.Discovery.Extensions
{
    public static class EventsClientExtensions
    {
        public static async Task<IReadOnlyCollection<Event>> GetAllSearchResults(
            this IEventsClient client, SearchEventsRequest request, CancellationToken ct)
        {
            var result = new List<Event>();
            var currentPage = 0;

            try
            {
                var total = 1;
                do
                {
                    request.AddQueryParameter("page", currentPage);
                    request.AddQueryParameter("sort", "date,asc");

                    await Task.Delay(1000, ct);

                    var response = await client.Search(request, ct);

                    result.AddRange(response.Data.Events);

                    currentPage++;
                    total = response.Page.TotalPages;

                } while (currentPage < total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new ReadOnlyCollection<Event>(result);
        }
    }
}
