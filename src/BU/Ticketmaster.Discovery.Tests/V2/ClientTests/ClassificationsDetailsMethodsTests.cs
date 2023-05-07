namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using AutoFixture;
    using Ticketmaster.Core;
    using Ticketmaster.Discovery.V2;
    using Ticketmaster.Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class ClassificationsDetailsMethodsTests : MethodTest
    {
        private readonly GetGenreDetailsResponse _response;

        private readonly ClassificationsClient _sut;

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

        [Fact]
        public async Task CallGetGenreDetailsAsync_ShouldIRestResponse()
        {
            IRestResponse response = await _sut.CallGetGenreDetailsAsync(new GetRequest("KnvZfZ7vA71"));
            Assert.NotNull(response);
            Assert.IsAssignableFrom<IRestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_response.ToString(), response.Content);
        }

        [Fact]
        public async Task CallGetSubGenreDetailsAsync_ShouldIRestResponse()
        {
            IRestResponse response = await _sut.CallGetSubSegmentDetailsAsync(new GetRequest("KZazBEonSMnZfZ7vFta"));
            Assert.NotNull(response);
            Assert.IsAssignableFrom<IRestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_response.ToString(), response.Content);
        }

        [Fact]
        public async Task GetGenreDetailsAsync_ShouldReturnGetGenreDetailsResponse()
        {
            GetGenreDetailsResponse response = await _sut.GetGenreDetailsAsync(new GetRequest("KnvZfZ7vA71"));
            Assert.NotNull(response);
            Assert.Equal(_response, response);
        }

        [Fact]
        public async Task GetSubGenreDetailsAsync_ShouldReturnGetGenreDetailsResponse()
        {
            GetGenreDetailsResponse response =
                await _sut.GetSubGenreDetailsAsync(new GetRequest("KZazBEonSMnZfZ7vFta"));
            Assert.NotNull(response);
            Assert.Equal(_response, response);
        }
    }
}