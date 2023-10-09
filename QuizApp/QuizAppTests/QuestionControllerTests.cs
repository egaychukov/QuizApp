using System.Net;
using QuizAppTests.Helpers;
using QuizApp.Controllers;
using QuizApp;
using QuizApp.Models;

namespace QuizAppTests
{
    public class QuestionControllerTests
    {
        [Fact]
        public async Task Get_ValidRequestParameters_QuestionNumberRemainsNotAffected()
        {
            // Arrange 
            var responseTextContent = FileHelpers.GetResponseContent("HistoryQuestions");
            var httpClientFactory = HttpClientHelpers.GetHttpClientFactoryMock(HttpStatusCode.OK, responseTextContent);
            var questionController = new QuestionController(httpClientFactory.Object);
            var questionRequest = new QuestionRequest() { Number = 2, Category = Category.History };

            // Act
            var questions = await questionController.Get(questionRequest);

            // Assert
            Assert.Equal(questionRequest.Number, questions.Count());
        }        
    }
}