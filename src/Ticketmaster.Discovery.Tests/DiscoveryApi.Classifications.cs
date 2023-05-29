using FluentAssertions;
using Ticketmaster.Core;
using Ticketmaster.Discovery.Models;
using Xunit;

namespace Ticketmaster.Discovery.Tests;

public partial class DiscoveryApiTests
{
    [Fact]
    public async Task Classifications_Search_GetDetails()
    {
        var searchRequest = new SearchClassificationsRequest().AddQueryParameter("size", 1);
        var searchResponse = await Api.Classifications.Search(searchRequest);

        var getRequest = new GetRequest(searchResponse.Embedded.Classifications.First().Segment.Id);
        var getResponse = await Api.Classifications.GetDetails(getRequest);

        getResponse.Should().NotBeNull();
    }
}