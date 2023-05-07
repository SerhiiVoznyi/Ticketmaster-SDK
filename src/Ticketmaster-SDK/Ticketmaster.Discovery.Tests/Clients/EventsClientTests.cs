using NSubstitute;
using RestSharp;
using Ticketmaster.Discovery.Models;
using Xunit;

namespace Ticketmaster.Discovery.Tests.Clients
{
    public class EventsClientTests : TestBase
    {
        [Theory]
        [InlineData(SearchEventsQueryParameters.attractionId, "K8vZ91713eV")]
        [InlineData(SearchEventsQueryParameters.venueId, "KovZpZAEdFtJ")]
        [InlineData(SearchEventsQueryParameters.postalCode, "90069")]
        [InlineData(SearchEventsQueryParameters.latlong, "34.0928090,-118.3286610")]
        [InlineData(SearchEventsQueryParameters.radius, "25")]
        [InlineData(SearchEventsQueryParameters.unit, "miles")]
        [InlineData(SearchEventsQueryParameters.source, "ticketmaster")]
        [InlineData(SearchEventsQueryParameters.marketId, "27")]
        [InlineData(SearchEventsQueryParameters.startDateTime, "2017-01-01T00:00:00Z")]
        [InlineData(SearchEventsQueryParameters.endDateTime, "2017-01-01T00:00:00Z")]
        [InlineData(SearchEventsQueryParameters.size, "1")]
        [InlineData(SearchEventsQueryParameters.page, "1")]
        [InlineData(SearchEventsQueryParameters.geoPoint, "9q5cgq7tn")]
        public async Task SearchEvents(SearchEventsQueryParameters key, string value)
        {


            var request = new SearchEventsRequest().AddQueryParameter(key, value);

            await new EventsClient(Client, Config).EventSearch(request);

            await Client
                .Received()
                .ExecuteAsync<SearchEventsResponse>(
                    Arg.Is<RestRequest>(
                        restRequest => restRequest.Parameters.Any(
                            p => p.Name == key.ToString() && Equals(p.Value, value))), CancellationToken.None);
        }
    }
}