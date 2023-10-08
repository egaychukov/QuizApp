namespace QuizApp.Models
{
    public class QuestionResponse
    {
        public int Response_Code { get; set; }
        public List<QuestionData> Results { get; set; }
    }
}
