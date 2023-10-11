using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IHttpClientFactory ClientFactory;

        public QuestionController(IHttpClientFactory clientFactory)
        {
            this.ClientFactory = clientFactory;
        }

        [HttpGet("{category}/{number:int:range(1,10)}")]
        public IEnumerable<QuestionData> GetAsync([FromRoute]QuestionRequest request)
        {
            var httpClient = ClientFactory.CreateClient();
            var url = $"https://opentdb.com/api.php?amount={request.Number}&category={(int)request.Category}";
            var response = httpClient.GetFromJsonAsync<QuestionResponse>(url).Result;
            return response!.Results;
        }
    }
}
