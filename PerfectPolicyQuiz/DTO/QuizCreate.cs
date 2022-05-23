using System;
using System.ComponentModel.DataAnnotations;

namespace PerfectPolicyQuiz.DTO
{
    public class QuizCreate
    {
        [Required]
        public string QuizTitle { get; set; }
        [Required]
        public string QuizTopic { get; set; }
        [Required]
        public string QuizCreatorName { get; set; }
        public DateTime CreatingDate { get; set; }
        [Required]
        public string PassPercentage { get; set; }
        public int UserInfoId { get; set; }
    }
}
