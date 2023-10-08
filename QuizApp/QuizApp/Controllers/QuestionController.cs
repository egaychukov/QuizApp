using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public QuestionController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        [HttpGet("{category}/{number:int}")]
        public async Task<string> Get([FromRoute]QuestionRequest request)
        {
            var httpClient = clientFactory.CreateClient();
            return await httpClient.GetStringAsync("https://opentdb.com/api.php?amount=10");
        }
    }
}
