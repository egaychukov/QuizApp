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

        [HttpGet("{category}/{number:int:range(1,10)}")]
        public async Task<IEnumerable<QuestionData>> Get([FromRoute]QuestionRequest request)
        {
            var httpClient = clientFactory.CreateClient();
            var url = $"https://opentdb.com/api.php?amount={request.Number}&category={(int)request.Category}";
            var response = await httpClient.GetFromJsonAsync<QuestionResponse>(url);
            return Enumerable.Empty<QuestionData>();
        }
    }
}
