using Xunit;

namespace Ticketmaster.Discovery.Tests
{
    public class DiscoveryApiTests
    {
        [Fact]
        public void Should_Construct()
        {
            var client = new DiscoveryApi("");
        }
    }
}
