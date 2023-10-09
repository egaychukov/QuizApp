using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Text;

namespace QuizAppTests
{
    public class QuestionControllerTests
    {
        public QuestionControllerTests()
        {

        }

        private static Mock<HttpMessageHandler> GetMessageHandlerMock(HttpStatusCode statusCode, string responseContent)
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