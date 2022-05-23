using PerfectPolicyQuiz.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace PerfectPolicyQuiz.DTO
{
    public class QuestionCreate
    {
        [Required]
        public string QuestionTopic { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public string QuestionImage { get; set; }
        // FK
        public int QuizId { get; set; }
    }
}
