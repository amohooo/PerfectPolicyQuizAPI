using System.Collections.Generic;

namespace PerfectPolicyQuiz.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionTopic { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImage { get; set; }

        // navigation properties
        public ICollection<Option> Options { get; set; }
        // m from 1-m
        public Quiz Quiz { get; set; }
        // 1 from 1-m

        // FK
        public int QuizId { get; set; }
        
    }
}
