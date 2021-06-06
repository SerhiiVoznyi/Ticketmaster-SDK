namespace Ticketmaster.Discovery.IntegrationTests.End2EndTests
{
    using Shouldly;
    using System.Threading.Tasks;
    using Ticketmaster.Discovery.V2.Models;
    using Xunit;

    public partial class DiscoveryApiClientTests
    {
        [Fact]
        public async Task FindSuggestAsync_Should_Return_FindSuggestResponse()
        {
            var sut = new DiscoveryApi();
            var request = new FindSuggestRequest();

            sut.Configure(_config);

            FindSuggestResponse result = await sut.Suggestions.FindSuggestAsync(request);

            result.Data.Attractions.ShouldNotBeEmpty();
            result.Data.Events.ShouldNotBeEmpty();
            result.Data.Products.ShouldNotBeEmpty();
            result.Data.Venues.ShouldNotBeEmpty();
        }
    }
}
