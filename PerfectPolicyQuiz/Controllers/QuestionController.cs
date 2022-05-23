using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPolicyQuiz.DTO;
using PerfectPolicyQuiz.Model;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPolicyQuiz.Controllers
{
    [Route("api/[controller]")]// give route pointer
    [ApiController]
    public class QuestionController : ControllerBase
    {
        /// <summary>
        /// make data read only
        /// </summary>
        private readonly QuizContext _questionContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionContext"></param>
        public QuestionController(QuizContext questionContext)
        {
            _questionContext = questionContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return Ok(_questionContext.Questions.AsAsyncEnumerable());
        }

        // GET: Questions

        [HttpGet("{id}")]
        public ActionResult<Question> GetSingle(int id)
        {
            var question = _questionContext.Questions.Find(id);

            return question == null ? NotFound() : question;

        }
        

        [HttpGet]
        [Route("GetForQuizId/{id}")]
        public ActionResult<IEnumerable<Question>> GetForQuizId(int id)
        {
            return Ok(_questionContext.Questions.Where(c => c.QuizId == id).AsEnumerable());
        }

        [HttpGet]
        [Route("QuestionWithOptions")]
        public ActionResult<Question> QuestionWithOptions(int id)
        {
            var question = _questionContext.Questions.Where((c) => c.QuestionId == id).Include(c => c.Options).FirstOrDefault();
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public void Post([FromBody] QuestionCreate question)
        {
            Question newQuestion = new Question
            {
                QuestionTopic = question.QuestionTopic,
                QuestionText = question.QuestionText,
                QuestionImage = question.QuestionImage,
                QuizId = question.QuizId
            };
            _questionContext.Questions.Add(newQuestion);
            _questionContext.SaveChanges();
        }

        // PUT api/<TafeClassController>/5

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Question> Put(int id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid data");
            }
            var existingQuestion = _questionContext.Questions.Where(c => c.QuestionId == id).FirstOrDefault();

            if (existingQuestion != null)
            {
                
                existingQuestion.QuestionTopic = question.QuestionTopic;
                existingQuestion.QuestionText = question.QuestionText;
                existingQuestion.QuestionImage = question.QuestionImage;
                existingQuestion.QuizId = question.QuizId;

                _questionContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Question> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid Quiz id");
            }

            var question = _questionContext.Questions.Where(c => c.QuestionId == id).FirstOrDefault();

            _questionContext.Remove(question);
            _questionContext.SaveChanges();

            return Ok();
        }
    }
}
