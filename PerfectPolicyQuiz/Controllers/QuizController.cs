using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPolicyQuiz.DTO;
using PerfectPolicyQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPolicyQuiz.Controllers
{
    // Route to the pointer that is pointing to "~api/controllerName"
    // "~" means the main address pointer. E.g. by using swagger "~" is https://localhost:44386/
    [Route("api/[controller]")]
    [ApiController]

    public class QuizController : ControllerBase
    {
        private readonly QuizContext _quizContext;
        /// <summary>
        /// Inject the Quiz data.
        /// </summary>
        /// <param name="quizContext"></param>
        public QuizController(QuizContext quizContext)
        {
            _quizContext = quizContext;
        }

        // [HttpGet] GET API Response
        /// <summary>
        /// Get all quizzes from injected quiz data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public ActionResult<IEnumerable<Quiz>> Get()
        {
            return Ok(_quizContext.Quizzes.AsEnumerable());
        }
        /// <summary>
        /// Get single quiz by identify quiz id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Quiz> Get(int id)
        {
            var quiz = _quizContext.Quizzes.Find(id);

            // return quiz: if quiz is not exist, return not found, otherwise, return quiz
            return quiz == null ? NotFound() : quiz;
        }
        /// <summary>
        /// Get all the quiz for a identified user (user by id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]

        // give the pointer "~/GetForUserInfoId/UserById"
        [Route("GetForUserInfoId/{id}")]
        public ActionResult<IEnumerable<Quiz>> GetForUserInfoId(int id)
        {
            // Using Linq to inherit from IEnumerable values in query expressions
            return Ok(_quizContext.Quizzes.Where(c => c.UserInfoId == id).AsEnumerable());
        }

        /// <summary>
        /// Get all quizzes 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("QuizzesByCreator/{name}")]
        public ActionResult<IEnumerable<Quiz>> QuizzesByCreator([FromRoute]string name)
        {
            return Ok(_quizContext.Quizzes.Where(c => c.QuizCreatorName == name).AsEnumerable());
        }

        [HttpGet]
        [Route("QuizWithQuestions")]
        public ActionResult<Quiz> GetWithQuestions(int id)
        {
            Quiz quiz = _quizContext.Quizzes.Where(c => c.QuizId == id).Include(c => c.Questions).FirstOrDefault();

            if (quiz != null)
            {
                return quiz;
            }
            return NotFound();
        }

        // implement http post in ASP.NET Core REST API. To create a new item
        /// <summary>
        /// Create a new quiz in quiz data, the data needs to be filled in with the required format and model
        /// </summary>
        /// <param name="quiz"></param>
        [HttpPost]
        public void Post([FromBody] QuizCreate quiz)
        {
            Quiz newQuiz = new Quiz
            {
                QuizTitle = quiz.QuizTitle,
                QuizTopic = quiz.QuizTopic,
                QuizCreatorName = quiz.QuizCreatorName,
                CreatingDate = quiz.CreatingDate,
                PassPercentage = quiz.PassPercentage,
                UserInfoId = quiz.UserInfoId
            };

            // add new quiz to quiz data list
            _quizContext.Quizzes.Add(newQuiz);

            // save changes to quiz data list
            _quizContext.SaveChanges();
        }
        
        /// <summary>
        /// Put method, to make changes to the existing (by) quiz and save it.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quiz"></param>
        /// <returns></returns>
        [Authorize] // Make only the authorised Put method can be pulled
        [HttpPut("{id}")] // retrieve the Http by id
        public ActionResult<Quiz> Put(int id, [FromBody] Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid data");
            }
            var existingQuiz = _quizContext.Quizzes.FirstOrDefault(c => c.QuizId == id);
            

            // check if the quiz is exist, make changes to the following model aspects.
            if (existingQuiz != null)
            {
                existingQuiz.QuizTitle = quiz.QuizTitle;
                existingQuiz.QuizTopic = quiz.QuizTopic;
                existingQuiz.QuizCreatorName = quiz.QuizCreatorName;
                existingQuiz.PassPercentage = quiz.PassPercentage;
                existingQuiz.UserInfoId = quiz.UserInfoId;

                // save changes
                _quizContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        /// <summary>
        /// Delete Method to delete a quiz by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Quiz> Delete(int id)
        {
            if (id <= 0) 
            { 
                return BadRequest("Not a valid Quiz id");
            }
            // use Linq to find the quiz of its Id
            var quiz = _quizContext.Quizzes.Where(c => c.QuizId == id).FirstOrDefault();

            // remove that quiz
            _quizContext.Remove(quiz);

            // save changes to the quiz data list
            _quizContext.SaveChanges();

            return Ok();
        }

    }
}
