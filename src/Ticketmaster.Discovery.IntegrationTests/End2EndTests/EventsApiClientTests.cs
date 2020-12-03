namespace Ticketmaster.Discovery.IntegrationTests.End2EndTests
{
    using Shouldly;
    using System.Threading.Tasks;
    using V2.Models;
    using Xunit;

    public partial class DiscoveryApiClientTests
    {
        [Fact]
        public async Task Events_SearchEventsAsync_Should_ReturnResult()
        {
            SearchEventsResponse result;

            using (var sut = _factory.Create<DiscoveryApi>(_config))
            {
                result = await sut.Events.SearchEventsAsync(new SearchEventsRequest());
            }

            result.ShouldNotBeNull();
            result._embedded.ShouldNotBeNull();
            result._embedded.Events.ShouldNotBeEmpty();
            result.Data.ShouldNotBeNull();
            result.Data.Events.ShouldNotBeEmpty();
            result.Page.ShouldNotBeNull();
            result.Links.ShouldNotBeNull();
        }
    }
}
