using FluentAssertions;
using Ticketmaster.Core;
using Ticketmaster.Discovery.Models;
using Xunit;

namespace Ticketmaster.Discovery.Tests;

public partial class DiscoveryApiTests
{
    [Fact]
    public async Task Attractions_Search_GetDetails()
    {
        var searchRequest = new SearchAttractionsRequest().AddQueryParameter("size", 1);
        var searchResponse = await Api.Attractions.Search(searchRequest);

        var getRequest = new GetRequest(searchResponse.Embedded.Attractions.First().Id);
        var getResponse = await Api.Attractions.GetDetails(getRequest);

        getResponse.Should().NotBeNull();
    }
}