using System.ComponentModel.DataAnnotations;

namespace PerfectPolicyQuiz.Controllers.DTO
{
    public class QuestionsPerQuizViewModel
    {
        [Required]
        public string QuizTitle { get; set; }
        [Required]
        public int QuestionsCount { get; set; }
    }

}
