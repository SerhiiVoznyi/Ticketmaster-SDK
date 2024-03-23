using FluentAssertions;
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

        searchResponse.Should().NotBeNull();
        searchResponse.Embedded.Should().NotBeNull();
        searchResponse.Embedded.Events.Should().NotBeEmpty();

        var @event = searchResponse.Embedded.Events.First();
        @event.Embedded.Attractions.Should().NotBeEmpty();

        var getRequest = new GetRequest(@event.Id);
        var getResponse = await Api.Events.GetDetails(getRequest);

        getResponse.Should().NotBeNull();

        var getImagesResponse = await Api.Events.GetImages(getRequest);

        getImagesResponse.Should().NotBeNull();
    }
}