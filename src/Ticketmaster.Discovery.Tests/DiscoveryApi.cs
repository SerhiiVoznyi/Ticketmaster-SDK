using FluentAssertions;
using Xunit;

namespace Ticketmaster.Discovery.Tests;

public partial class DiscoveryApiTests
{
    private DiscoveryApi Api { get; }

    public DiscoveryApiTests()
    {
        Api = new DiscoveryApi("YOUR CLIENT API KEY");
    }

    [Fact]
    public void DiscoveryApi_Should_Construct()
    {
        Api.Attractions.Should().NotBeNull();
        Api.Classifications.Should().NotBeNull();
        Api.Events.Should().NotBeNull();
        Api.Suggestions.Should().NotBeNull();
        Api.Venues.Should().NotBeNull();
    }
}