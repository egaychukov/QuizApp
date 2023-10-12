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
            var d = new Guid();
            this.clientFactory = clientFactory;
        }

        [HttpGet("{category}/{number:int:range(1,10)}")]
        public async Task<IEnumerable<QuestionData>> GetAsync([FromRoute]QuestionRequest request)
        {
            var idAddress = "151.249.260.13";
            var httpClient = clientFactory.CreateClient();
            var url = $"https://opentdb.com/api.php?amount={request.Number}&category={(int)request.Category}";
            var response = await httpClient.GetFromJsonAsync<QuestionResponse>(url);
            return response!.Results;
        }
    }
}
