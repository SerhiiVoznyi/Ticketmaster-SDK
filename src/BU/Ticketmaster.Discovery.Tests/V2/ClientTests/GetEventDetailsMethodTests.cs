namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.V2;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class GetEventDetailsMethodTests : MethodTest
    {
        private readonly Event _expectedResult;

        private readonly EventsClient _sut;

        public GetEventDetailsMethodTests()
        {
            var fixture = new Fixture();
            _expectedResult = fixture.Create<Event>();


            Client
                .ExecuteAsync<Event>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<Event>
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
        public async Task CallGetEventDetailsAsync_ShouldReturnIRestResponse()
        {
            IRestResponse response = await _sut.CallGetEventDetailsAsync(new GetRequest("Z1lMVSyiJynZ177dJa"));
            Assert.NotNull(response);
            Assert.IsType<RestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task GetEventDetailsAsync_ShouldReturnEvent_IfEventExist()
        {
            Event response = await _sut.GetEventDetailsAsync(new GetRequest("Z1lMVSyiJynZ177dJa"));
            Assert.NotNull(response);
            Assert.Equal(_expectedResult, response);
        }

        [Theory]
        [InlineData(HttpStatusCode.Accepted)]
        [InlineData(HttpStatusCode.Ambiguous)]
        [InlineData(HttpStatusCode.BadGateway)]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Conflict)]
        [InlineData(HttpStatusCode.Created)]
        [InlineData(HttpStatusCode.InternalServerError)]
        [InlineData(HttpStatusCode.Continue)]
        [InlineData(HttpStatusCode.ExpectationFailed)]
        [InlineData(HttpStatusCode.GatewayTimeout)]
        [InlineData(HttpStatusCode.Gone)]
        [InlineData(HttpStatusCode.NonAuthoritativeInformation)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        public async Task GetEventDetailsAsync_ShouldThrowException_WhenResponseCodeNotOk(HttpStatusCode statusCode)
        {
            Client
                .ExecuteAsync<Event>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<Event>
                {
                    StatusCode = statusCode
                });

            await Assert.ThrowsAnyAsync<InvalidDataException>(
                () => _sut.GetEventDetailsAsync(new GetRequest("invalid id")));
        }
    }
}