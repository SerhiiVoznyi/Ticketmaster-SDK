namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Ticketmaster.Core;
    using Ticketmaster.Discovery.V2;
    using Ticketmaster.Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class GetEventImagesMethodTests : MethodTest
    {
        private readonly GetEventImagesResponse _expectedResult;

        private readonly EventsClient _sut;

        public GetEventImagesMethodTests()
        {
            _expectedResult = Fixture.Create<GetEventImagesResponse>();

            Client
                .ExecuteAsync<GetEventImagesResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<GetEventImagesResponse>
                {
                    Data = _expectedResult,
                    StatusCode = HttpStatusCode.OK
                });
            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = "{jobject: { this: 1 }}"
                });
            _sut = new EventsClient(Client, Config);
        }

        [Fact]
        public async Task CallGetEventImagesAsync_ShouldReturnIRstResponse()
        {
            IRestResponse response = await _sut.CallGetEventImagesAsync(new GetRequest("Z1lMVSyiJynZ177dJa"));
            Assert.NotNull(response);
            Assert.IsType<RestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task GetEventImagesAsync_ShouldReturnGetEventImagesResponse()
        {
            GetEventImagesResponse response = await _sut.GetEventImagesAsync(new GetRequest("Z1lMVSyiJynZ177dJa"));
            Assert.NotNull(response);
            Assert.Equal(_expectedResult, response);
        }
    }
}