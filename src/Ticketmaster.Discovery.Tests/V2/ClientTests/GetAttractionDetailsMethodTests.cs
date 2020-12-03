namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using AutoFixture;
    using Core;
    using Core.V2.Models;
    using Discovery.V2;
    using NSubstitute;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class GetAttractionDetailsMethodTests : MethodTest
    {
        public GetAttractionDetailsMethodTests()
        {
            _expectedResponse = Fixture.Create<Attraction>();
            Client
                .ExecuteAsync<Attraction>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<Attraction>
                {
                    Data = _expectedResponse,
                    StatusCode = HttpStatusCode.OK
                });
            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    Content = _expectedResponse.ToString(),
                    StatusCode = HttpStatusCode.OK
                });
            _sut = new AttractionsClient(Client, Config);
        }

        private readonly IAttractionsClient _sut;
        private readonly Attraction _expectedResponse;

        [Fact]
        public async Task CallSearchAttractionsAsync_ShouldReturnISearchResponse()
        {
            var response = await _sut.CallGetAttractionDetailsAsync(new GetRequest("K8vZ9175BhV"));
            Assert.NotNull(response);
            Assert.Equal(_expectedResponse.ToString(), response.Content);
        }

        [Fact]
        public async Task SearchAttractionsAsync_ShouldReturnSearchAttractionsResponse()
        {
            var response = await _sut.GetAttractionDetailsAsync(new GetRequest("K8vZ9175BhV"));
            Assert.NotNull(response);
            Assert.Equal(_expectedResponse, response);
        }
    }
}