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

        [Fact]
        public async Task Get_ValidRequestParameters_QuestionsAreNotModified()
        {
            // Arrange
            var responseTextContent = FileHelpers.GetResponseContent("SingleAnimalQuestion");
            var httpClientFactory = HttpClientHelpers.GetHttpClientFactoryMock(HttpStatusCode.OK, responseTextContent);
            var questionController = new QuestionController(httpClientFactory.Object);
            var questionResponse = FileHelpers.GetEntityFromJson<QuestionResponse>("SingleAnimalQuestion");
            var expectedQuestion = questionResponse.Results.FirstOrDefault();

            // Act
            var questions = await questionController.Get(new QuestionRequest());

            // Assert
            var actualQuestion = questions.FirstOrDefault();
            
            Assert.Equal(expectedQuestion.Question, actualQuestion.Question);
            Assert.Equal(expectedQuestion.Correct_Answer, actualQuestion.Correct_Answer);
            Assert.True(Enumerable.SequenceEqual(expectedQuestion.Incorrect_Answers, actualQuestion.Incorrect_Answers));
        }

        [Fact]
        public async Task get_InternalApiResponsesWithError_ThrowsHttpRequestException()
        {
            // Arrange
            var httpClientFactory = HttpClientHelpers.GetHttpClientFactoryMock(HttpStatusCode.NotFound, string.Empty);
            var questionController = new QuestionController(httpClientFactory.Object);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () => await questionController.Get(new QuestionRequest()));
        }
    }
}