using PerfectPolicyQuiz.Model;
using System.ComponentModel.DataAnnotations;

namespace PerfectPolicyQuiz.DTO
{
    public class OptionsCreate
    {
        [Required]
        public string OptionText { get; set; }
        public string OptionLetter { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        //public Question Question { get; set; }
        
    }
}
