namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Ticketmaster.Discovery.V2;
    using Ticketmaster.Discovery.V2.Models;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class SearchEventsMethodTests : MethodTest
    {
        private readonly SearchEventsResponse _searchEventsResponse;

        private readonly EventsClient _sut;

        public SearchEventsMethodTests()
        {
            _searchEventsResponse = Fixture.Create<SearchEventsResponse>();
            Client
                .ExecuteAsync<SearchEventsResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<SearchEventsResponse>
                {
                    Data = _searchEventsResponse,
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
        public async Task CallSearchEventsAsync_ShouldReturnIRestResponse()
        {
            IRestResponse response = await _sut.CallSearchEventsAsync(new SearchEventsRequest());
            Assert.NotNull(response);
            Assert.IsType<RestResponse>(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
        }

        [Theory]
        [InlineData(SearchEventsQueryParameters.attractionId, "K8vZ91713eV")]
        [InlineData(SearchEventsQueryParameters.venueId, "KovZpZAEdFtJ")]
        [InlineData(SearchEventsQueryParameters.postalCode, "90069")]
        [InlineData(SearchEventsQueryParameters.latlong, "34.0928090,-118.3286610")]
        [InlineData(SearchEventsQueryParameters.radius, "25")]
        [InlineData(SearchEventsQueryParameters.unit, "miles")]
        [InlineData(SearchEventsQueryParameters.source, "ticketmaster")]
        [InlineData(SearchEventsQueryParameters.marketId, "27")]
        [InlineData(SearchEventsQueryParameters.startDateTime, "2017-01-01T00:00:00Z")]
        [InlineData(SearchEventsQueryParameters.endDateTime, "2017-01-01T00:00:00Z")]
        [InlineData(SearchEventsQueryParameters.size, "1")]
        [InlineData(SearchEventsQueryParameters.page, "1")]
        [InlineData(SearchEventsQueryParameters.geoPoint, "9q5cgq7tn")]
        public async Task SearchEventsAsync_ShouldBuildRequestWithQueryParameters(SearchEventsQueryParameters key,
            string value)
        {
            var request = new SearchEventsRequest();
            request.AddQueryParameter(key, value);
            await _sut.SearchEventsAsync(request);

            await Client
                .Received()
                .ExecuteAsync<SearchEventsResponse>(
                    Arg.Is<RestRequest>(
                        restRequest => restRequest.Parameters.Any(
                            p => p.Name == key.ToString() && Equals(p.Value, value))));
        }

        [Fact]
        public async Task SearchEventsAsync_ShouldReturnParsedRespond_WhenStatusCodeIsHttpStatusCodeOK()
        {
            SearchEventsResponse result = await _sut.SearchEventsAsync(new SearchEventsRequest());

            Assert.NotNull(result);
            Assert.NotNull(result.Links);
            Assert.NotNull(result._embedded);
            Assert.NotNull(result.Page);
            Assert.Equal(_searchEventsResponse, result);
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
        public async Task SearchEventsAsync_ShouldThrowException_WhenResponseCodeNotOk(HttpStatusCode statusCode)
        {
            Client
                .ExecuteAsync<SearchEventsResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<SearchEventsResponse>
                {
                    StatusCode = statusCode
                });

            await Assert.ThrowsAnyAsync<InvalidDataException>(() => _sut.SearchEventsAsync(new SearchEventsRequest()));
        }
    }
}