using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPolicyQuiz.Controllers.DTO;
using PerfectPolicyQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectPolicyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly QuizContext _quizContext;

        public ReportController(QuizContext quizContext)
        {
            _quizContext = quizContext;
        }
        [HttpGet]
        public IActionResult QuestionsPerQuizReport()//DateTime start, DateTime finish)
        {
            var quizWithQuestions = _quizContext.Quizzes.Include(c => c.Questions);

            List<QuestionsPerQuizViewModel> reportData = quizWithQuestions.Select(c => new QuestionsPerQuizViewModel
            {
                QuizTitle = c.QuizTitle,
                QuestionsCount = c.Questions.Count
            }).ToList();

            return Ok(reportData);
        }

    }
}