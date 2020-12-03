namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Core;
    using Core.V2.Models;
    using Discovery.V2;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class GetVenueDetailsMethodTests : MethodTest
    {
        public GetVenueDetailsMethodTests()
        {
            _venue = Fixture.Create<Venue>();
            Client
                .ExecuteAsync<Venue>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<Venue>
                {
                    Data = _venue,
                    StatusCode = HttpStatusCode.OK
                });
            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = _venue.ToString()
                });
            _sut = new VenuesClient(Client, Config);
        }

        private readonly VenuesClient _sut;
        private readonly Venue _venue;

        [Fact]
        public async Task CallGetVenueDetailsAsync_ShouldReturnIRestResponse()
        {
            var result = await _sut.CallGetVenueDetailsAsync(new GetRequest(""));
            Assert.NotNull(result);
            Assert.IsType<RestResponse>(result);
            Assert.Equal(_venue.ToString(), result.Content);
        }

        [Fact]
        public async Task GetVenueDetailsAsync_ShouldReturnClassification()
        {
            var result = await _sut.GetVenueDetailsAsync(new GetRequest(""));
            Assert.Equal(_venue, result);
        }
    }
}