namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Ticketmaster.Core.V2.Models;
    using Ticketmaster.Discovery.V2;
    using Ticketmaster.Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class SearchAttractionsMethodTests : MethodTest
    {
        private readonly SearchAttractionsResponse _expectedResponse;

        private readonly AttractionsClient _sut;

        public SearchAttractionsMethodTests()
        {
            _expectedResponse = Fixture.Create<SearchAttractionsResponse>();

            Client
                .ExecuteAsync<SearchAttractionsResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<SearchAttractionsResponse>
                {
                    Data = _expectedResponse,
                    StatusCode = HttpStatusCode.OK
                });
            _sut = new AttractionsClient(Client, Config);
        }


        [Theory]
        [InlineData(QueryParameters.size, "1")]
        [InlineData(QueryParameters.page, "1")]
        public async Task CallSearchAttractionsAsync_ShouldBuildRequestWithQueryParameters(QueryParameters key,
            string value)
        {
            var request = new SearchAttractionsRequest();
            request.AddQueryParameter(key, value);

            await _sut.CallSearchAttractionsAsync(request);

            await Client
                .Received()
                .ExecuteAsync(
                    Arg.Is<RestRequest>(
                        restRequest => restRequest.Parameters.Any(
                            p => p.Name == key.ToString() && Equals(p.Value, value))));
        }

        [Theory]
        [InlineData(QueryParameters.size, "1")]
        [InlineData(QueryParameters.page, "1")]
        public async Task SearchAttractionsAsync_ShouldBuildRequestWithQueryParameters(QueryParameters key,
            string value)
        {
            var request = new SearchAttractionsRequest();


            request.AddQueryParameter(key, value);

            await _sut.SearchAttractionsAsync(request);

            await Client
                .Received()
                .ExecuteAsync<SearchAttractionsResponse>(
                    Arg.Is<RestRequest>(
                        restRequest => restRequest.Parameters.Any(
                            p => p.Name == key.ToString() && Equals(p.Value, value))));
        }

        [Fact]
        public async Task SearchAttractionsAsync_ShouldReturnSearchAttractionsResponse()
        {
            SearchAttractionsResponse response = await _sut.SearchAttractionsAsync(new SearchAttractionsRequest());
            Assert.NotNull(response);
            Assert.Equal(_expectedResponse, response);
        }
    }
}