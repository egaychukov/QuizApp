namespace QuizApp.Models
{
    public class QuestionData
    {
        public string Question { get; set; }
        public string Correct_Answer { get; set; }
        public List<string> Incorrect_Answers { get; set; }
    }
}