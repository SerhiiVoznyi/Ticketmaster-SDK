using RestSharp;
using System.Net;

namespace Ticketmaster.Discovery.Tests
{
    public static class MockD
    {
        public static IRestClient MockRestClient<T>(HttpStatusCode httpStatusCode, T data)
            where T : new()
        {
            var response = new Mock<RestResponse<T>>();
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup(x => x.Execute<T>(It.IsAny<IRestRequest>()))
                .ReturnsAsync(response.Object);
            return mockIRestClient.Object;
        }
    }
}
