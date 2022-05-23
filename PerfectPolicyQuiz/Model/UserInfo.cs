using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicyQuiz.Model
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Quiz> Quizzes { get; set; }
    }
}
