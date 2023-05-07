namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using AutoFixture;
    using Ticketmaster.Core;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.V2;
    using NSubstitute;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class GetAttractionDetailsMethodTests : MethodTest
    {
        private readonly Attraction _expectedResponse;

        private readonly IAttractionsClient _sut;

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

        [Fact]
        public async Task CallSearchAttractionsAsync_ShouldReturnISearchResponse()
        {
            IRestResponse response = await _sut.CallGetAttractionDetailsAsync(new GetRequest("K8vZ9175BhV"));
            Assert.NotNull(response);
            Assert.Equal(_expectedResponse.ToString(), response.Content);
        }

        [Fact]
        public async Task SearchAttractionsAsync_ShouldReturnSearchAttractionsResponse()
        {
            Attraction response = await _sut.GetAttractionDetailsAsync(new GetRequest("K8vZ9175BhV"));
            Assert.NotNull(response);
            Assert.Equal(_expectedResponse, response);
        }
    }
}