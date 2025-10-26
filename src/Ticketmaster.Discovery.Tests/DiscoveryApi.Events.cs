using Shouldly;
using Ticketmaster.Discovery.Extensions;
using Ticketmaster.Discovery.Models;
using Xunit;

namespace Ticketmaster.Discovery.Tests;

public partial class DiscoveryApiTests
{
    [Fact]
    public async Task Events_Search_GetDetails()
    {
        var searchRequest = new SearchEventsRequest().AddQueryParameter("size", 1);
        var searchResponse = await Api.Events.Search(searchRequest);

        searchResponse.ShouldNotBeNull();
        searchResponse.Embedded.ShouldNotBeNull();
        searchResponse.Embedded.Events.ShouldNotBeNull();

        var @event = searchResponse.Embedded.Events.First();
        @event.Embedded.Attractions.ShouldNotBeNull();

        var getRequest = new GetRequest(@event.Id);
        var getResponse = await Api.Events.GetDetails(getRequest);

        getResponse.ShouldNotBeNull();

        var getImagesResponse = await Api.Events.GetImages(getRequest);

        getImagesResponse.ShouldNotBeNull();
    }

    [Fact]
    public async Task DiscoveryApi_GetAll_ShouldWork()
    {
        var result =
            await Api.Events.GetAllSearchResults(
                new SearchEventsRequest()
                    .AddQueryParameter("city", "Wroclaw"),
                CancellationToken.None);

        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task DiscoveryApi_GetAll_ShouldWork2()
    {
        var result =
            await Api.Events.GetAllSearchResults(
                new SearchEventsRequest()
                    .AddQueryByPreSaleDateTime(new DateTime(2025, 1, 1), null),
                CancellationToken.None);

        result.ShouldNotBeNull();
    }
}