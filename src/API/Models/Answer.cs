using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
