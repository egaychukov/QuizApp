using Moq;
using Moq.Protected;
using System.Net;
using System.Text;

namespace QuizAppTests.Helpers
{
    internal static class HttpClientHelpers
    {
        public static Mock<IHttpClientFactory> GetHttpClientFactoryMock(HttpStatusCode statusCode, string responseContent)
        {
            var messageHandler = GetMessageHandlerMock(statusCode, responseContent);
            var httpClient = new HttpClient(messageHandler.Object);
            var mockFactory = new Mock<IHttpClientFactory>();
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
            return mockFactory;
        }

        public static Mock<HttpMessageHandler> GetMessageHandlerMock(HttpStatusCode statusCode, string responseContent)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
                });
            return mockHttpMessageHandler;
        }
    }
}
