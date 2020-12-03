namespace Ticketmaster.Discovery.IntegrationTests.End2EndTests
{
    using V2;
    using Xunit;

    public partial class DiscoveryApiClientTests
    {
        [Fact]
        public void ClientFactory_ShouldCreate_DiscoveryApiClient()
        {
            Assert.NotNull(_sut);
            Assert.IsType<DiscoveryApi>(_sut);
        }

        [Fact]
        public void ClientFactory_Configure_EventsApiClient()
        {
            Assert.NotNull(_sut.Events);
            Assert.IsType<EventsClient>(_sut.Events);
        }

        [Fact]
        public void ClientFactory_Configure_AttractionsApiClient()
        {
            Assert.NotNull(_sut.Attractions);
            Assert.IsType<AttractionsClient>(_sut.Attractions);
        }

        [Fact]
        public void ClientFactory_Configure_VenuesApiClient()
        {
            Assert.NotNull(_sut.Venues);
            Assert.IsType<VenuesClient>(_sut.Venues);
        }

        [Fact]
        public void ClientFactory_Configure_ClassificationsApiClient()
        {
            Assert.NotNull(_sut.Classifications);
            Assert.IsType<ClassificationsClient>(_sut.Classifications);
        }
    }
}
