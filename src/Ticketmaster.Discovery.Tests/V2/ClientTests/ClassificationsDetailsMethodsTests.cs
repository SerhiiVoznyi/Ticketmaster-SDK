namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using AutoFixture;
    using Core;
    using Discovery.V2;
    using Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class ClassificationsDetailsMethodsTests : MethodTest
    {
        public ClassificationsDetailsMethodsTests()
        {
            _response = Fixture.Create<GetGenreDetailsResponse>();
            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = _response.ToString()
                });
            Client
                .ExecuteAsync<GetGenreDetailsResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<GetGenreDetailsResponse>
                {
                    Data = _response,
                    StatusCode = HttpStatusCode.OK
                });
            _sut = new ClassificationsClient(Client, Config);
        }

        private readonly ClassificationsClient _sut;
        private readonly GetGenreDetailsResponse _response;

        [Fact]
        public async Task CallGetGenreDetailsAsync_ShouldIRestResponse()
        {
            var response = await _sut.CallGetGenreDetailsAsync(new GetRequest("KnvZfZ7vA71"));
            Assert.NotNull(response);
            Assert.IsAssignableFrom<IRestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_response.ToString(), response.Content);
        }

        [Fact]
        public async Task CallGetSubGenreDetailsAsync_ShouldIRestResponse()
        {
            var response = await _sut.CallGetSubSegmentDetailsAsync(new GetRequest("KZazBEonSMnZfZ7vFta"));
            Assert.NotNull(response);
            Assert.IsAssignableFrom<IRestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_response.ToString(), response.Content);
        }

        [Fact]
        public async Task GetGenreDetailsAsync_ShouldReturnGetGenreDetailsResponse()
        {
            var response = await _sut.GetGenreDetailsAsync(new GetRequest("KnvZfZ7vA71"));
            Assert.NotNull(response);
            Assert.Equal(_response, response);
        }

        [Fact]
        public async Task GetSubGenreDetailsAsync_ShouldReturnGetGenreDetailsResponse()
        {
            var response = await _sut.GetSubGenreDetailsAsync(new GetRequest("KZazBEonSMnZfZ7vFta"));
            Assert.NotNull(response);
            Assert.Equal(_response, response);
        }
    }
}