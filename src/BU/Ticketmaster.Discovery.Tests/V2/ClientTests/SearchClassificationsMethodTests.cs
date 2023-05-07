namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Ticketmaster.Discovery.V2;
    using Ticketmaster.Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class SearchClassificationsMethodTests : MethodTest
    {
        private readonly SearchClassificationsResponse _expectedResponse;

        private readonly ClassificationsClient _sut;

        public SearchClassificationsMethodTests()
        {
            var fixture = new Fixture();
            _expectedResponse = fixture.Create<SearchClassificationsResponse>();
            Client
                .ExecuteAsync<SearchClassificationsResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<SearchClassificationsResponse>
                {
                    Data = _expectedResponse,
                    StatusCode = HttpStatusCode.OK
                });
            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = "{jobject: { this: 1 }}"
                });
            _sut = new ClassificationsClient(Client, Config);
        }

        [Fact]
        public async Task SearchClassificationsAsync_ShouldReturnIRestResponse()
        {
            IRestResponse result = await _sut.CallSearchClassificationsAsync(new SearchClassificationsRequest());
            Assert.NotNull(result);
            Assert.IsType<RestResponse>(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task SearchClassificationsAsync_ShouldReturnSearchClassificationsResponse()
        {
            SearchClassificationsResponse result =
                await _sut.SearchClassificationsAsync(new SearchClassificationsRequest());
            Assert.NotNull(result);
            Assert.Equal(_expectedResponse, result);
        }
    }
}