using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        [HttpGet("{category}/{number:int}")]
        public string Get([FromRoute]QuestionRequest request)
        {
            return $"{request.Category} {request.Number}";
        }
    }
}
