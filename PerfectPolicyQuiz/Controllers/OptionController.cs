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
    
    [Route("api/[controller]")] // give pointer to the route
    [ApiController]
    
    public class OptionController : ControllerBase
    {
        
        // set option data from seeding data to be read only
        private readonly QuizContext _optionContext;

        /// <summary>
        /// Dependency Injection: inject the data to be used by option controllers class
        /// </summary>
        /// <param name="optionContext"></param>
        public OptionController(QuizContext optionContext)
        {
            _optionContext = optionContext;
        }
        /// <summary>
        /// "Get" all option method
        /// </summary>
        /// <returns>return all options</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Option>> Get()
        {
            return Ok(_optionContext.Options.AsEnumerable());
        }


        // GET: Questions
        /// <summary>
        /// Get single option by its id
        /// </summary>
        /// <param name="id">option id to be found</param>
        /// <returns>when the id had be found, return this option</returns>
        [HttpGet("{id}")]
        public ActionResult<Option> Get(int id)
        {
            var option = _optionContext.Options.Find(id);
            
            // return option: if option is null return not found, otherwise return option.
            return option == null ? NotFound() : option;

        }

        /// <summary>
        /// "Get" all the options to its question (by question id)
        /// a route must be given in order to set the pointer when navigating
        /// </summary>
        /// <param name="id">based on which question id that the options belong to</param>
        /// <returns>when the searched id is mathching with the id that need to be find</returns>
        [HttpGet]
        [Route("GetForQuestionId/{id}")]
        public ActionResult<IEnumerable<Quiz>> GetForQuestionId(int id)
        {
            //using Linq: to identify question by its id
            return Ok(_optionContext.Options.Where(c => c.QuestionId == id).AsEnumerable());
        }

        /// <summary>
        /// "POST" method in API, could "create" new option
        /// with required format
        /// </summary>
        /// <param name="option"></param>
        [HttpPost]
        public void Post([FromBody] OptionsCreate option)
        {
            Option newOption = new Option
            {
                OptionText = option.OptionText,
                OptionLetter = option.OptionLetter,
                IsCorrect = option.IsCorrect,
                QuestionId = option.QuestionId
            };

            //add new option to the option list
            _optionContext.Options.Add(newOption);
            //save the new added option
            _optionContext.SaveChanges();
            
        }
        // PUT api/<UnitController>/5

        /// <summary>
        /// "PUT" option to update the changes to the existing option
        /// </summary>
        /// <param name="id">to identify which option need to be modified</param>
        /// <param name="option">to update the element within the option class</param>
        /// <returns></returns>
        [Authorize]//make this method authorised to be done
        [HttpPut("{id}")]
        public ActionResult<Option> Put(int id, [FromBody] Option option)
        {
            // the data to be modified has to be the same model format as what an option required
            // otherwise return bad request
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid data");
            }
            var existingOption = _optionContext.Options.Where(c => c.OptionId == id).FirstOrDefault();

            // when the option exist
            if (existingOption != null)
            {
                existingOption.OptionLetter = option.OptionLetter;
                existingOption.OptionText = option.OptionText;
                existingOption.IsCorrect = option.IsCorrect;

                existingOption.QuestionId = option.QuestionId;

                //save updates
                _optionContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<UnitController>/5
        /// <summary>
        /// "Delete" method to delete an option
        /// </summary>
        /// <param name="id">to indicate the option that need to be deleted</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Option> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid Quiz id");
            }

            var optinon = _optionContext.Options.Where(c => c.OptionId == id).FirstOrDefault();

            // remove the option by finging its id
            _optionContext.Remove(optinon);
            // save changes
            _optionContext.SaveChanges();

            return Ok();
        }
    }

}
