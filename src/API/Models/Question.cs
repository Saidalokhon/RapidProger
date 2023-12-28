namespace API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public QuestionType Type { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }

    public enum QuestionType
    {
        Checkbox,
        Radio,
        OpenQuestion
    }
}
