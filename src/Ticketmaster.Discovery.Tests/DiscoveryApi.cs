using Shouldly;
using Xunit;

namespace Ticketmaster.Discovery.Tests;

public partial class DiscoveryApiTests
{
    private DiscoveryApi Api { get; }

    public DiscoveryApiTests()
    {
        Api = new DiscoveryApi("I5Ux5I2PTXJqf300FBHnaWkaRhwWApvq");
    }

    [Fact]
    public void DiscoveryApi_Should_Construct()
    {
        Api.Attractions.ShouldNotBeNull();
        Api.Classifications.ShouldNotBeNull();
        Api.Events.ShouldNotBeNull();
        Api.Suggestions.ShouldNotBeNull();
        Api.Venues.ShouldNotBeNull();
    }
}