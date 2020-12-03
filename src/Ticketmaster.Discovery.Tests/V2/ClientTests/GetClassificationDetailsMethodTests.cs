namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using Core;
    using Core.V2.Models;
    using Discovery.V2;
    using NSubstitute;
    using RestSharp;
    using Xunit;

    public class GetClassificationDetailsMethodTests : MethodTest
    {
        public GetClassificationDetailsMethodTests()
        {
            _classification = Fixture.Create<Classification>();

            Client
                .ExecuteAsync<Classification>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<Classification>
                {
                    Data = _classification,
                    StatusCode = HttpStatusCode.OK
                });

            Client
                .ExecuteAsync(Arg.Any<IRestRequest>())
                .Returns(new RestResponse
                {
                    Content = _classification.ToString(),
                    StatusCode = HttpStatusCode.OK
                });

            _sut = new ClassificationsClient(Client, Config);
        }

        private readonly ClassificationsClient _sut;
        private readonly Classification _classification;

        [Fact]
        public async Task CallGetClassificationDetailsAsync_ShouldReturnIRestResponse()
        {
            var result = await _sut.CallGetClassificationDetailsAsync(new GetRequest(""));
            Assert.NotNull(result);
            Assert.IsType<RestResponse>(result);
            Assert.Equal(_classification.ToString(), result.Content);
        }

        [Fact]
        public async Task GetClassificationDetailsAsync_ShouldReturnClassification()
        {
            var result = await _sut.GetClassificationDetailsAsync(new GetRequest(""));
            Assert.Equal(_classification, result);
        }
    }
}