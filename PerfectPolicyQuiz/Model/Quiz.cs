using System;
using System.Collections.Generic;

namespace PerfectPolicyQuiz.Model
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public string QuizTopic { get; set; }
        public string QuizCreatorName { get; set; }
        public DateTime CreatingDate { get; set; }

        public string PassPercentage { get; set; }

        //public Question Questions { get; set; }
        public ICollection<Question> Questions { get; set; } 
        //for 1 from 1-m
        public UserInfo UserInfo { get; set; }
        public int UserInfoId { get; set; }
    }
}
