namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Discovery.V2;
    using Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class SearchVenuesMethodTests : MethodTest
    {
        public SearchVenuesMethodTests()
        {
            _response = Fixture.Create<SearchVenuesResponse>();
            Client
                .ExecuteAsync<SearchVenuesResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<SearchVenuesResponse>
                {
                    Data = _response,
                    StatusCode = HttpStatusCode.OK
                });
            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = _response.ToString()
                });
            _sut = new VenuesClient(Client, Config);
        }

        private readonly VenuesClient _sut;
        private readonly SearchVenuesResponse _response;

        [Fact]
        public async Task CallSearchVenuesAsync_ShouldReturnSearchVenuesResponse()
        {
            var response = await _sut.CallSearchVenuesAsync(new SearchVenuesRequest());
            Assert.NotNull(response);
            Assert.Equal(_response.ToString(), response.Content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task SearchVenuesAsync_ShouldReturnSearchVenuesResponse()
        {
            var response = await _sut.SearchVenuesAsync(new SearchVenuesRequest());
            Assert.NotNull(response);
            Assert.Equal(_response, response);
        }
    }
}