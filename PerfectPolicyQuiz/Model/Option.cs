using System.Collections.Generic;

namespace PerfectPolicyQuiz.Model
{
    public class Option
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public string OptionLetter { get; set; }
        public bool IsCorrect { get; set; }

        //public ICollection<Question> Questions { get; set; } for m from 1-m
        public Question Question { get; set; }
        // FK
        public int QuestionId { get; set; }
    }
}
