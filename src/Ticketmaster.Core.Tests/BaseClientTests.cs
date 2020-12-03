namespace Ticketmaster.Core.Tests
{
    using AutoFixture;
    using NSubstitute;
    using RestSharp;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Xunit;

    public class BaseClientImplementation : BaseClient
    {
        public BaseClientImplementation(IRestClient client, IClientConfig config)
            : base(client, config)
        {
        }

        public Task<IApiResponse> Execute(IRestRequest request, HttpStatusCode code)
        {
            return ExecuteRequestAsync<IApiResponse>(request, code);
        }
    }

    public class BaseClientTests
    {
        public BaseClientTests()
        {
            _fixture = new Fixture();
            _config = Substitute.For<IClientConfig>();
            _config.ConsumerKey.Returns("");
            _config.ApiRootUrl.Returns("https://app.ticketmaster.com/discovery/");
            _client = Substitute.For<IRestClient>();
            _sut = new BaseClientImplementation(_client, _config);
        }

        private const string EventsPath = "/v2/events.json";
        private readonly IRestClient _client;
        private readonly IClientConfig _config;
        private readonly Fixture _fixture;
        private readonly BaseClientImplementation _sut;

        [Fact]
        public async Task ExecuteRequestAsync_ShouldValidateResponse()
        {
            _client
                .ExecuteAsync<IApiResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<IApiResponse>
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content =
                        "{ \"fault\": { \"faultstring\": \"Invalid ApiKey\", \"detail\": { \"errorcode\": \"oauth.v2.InvalidApiKey\" } } }"
                });


            var searchRequest = new RestRequest(EventsPath, Method.GET) { RequestFormat = DataFormat.Json };
            await Assert.ThrowsAnyAsync<InvalidDataException>(() => _sut.Execute(searchRequest, HttpStatusCode.OK));
        }
    }
}