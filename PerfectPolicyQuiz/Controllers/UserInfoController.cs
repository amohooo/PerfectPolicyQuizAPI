using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectPolicyQuiz.DTO;
using PerfectPolicyQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectPolicyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        // GET: api/<UserInfoController>
        // Make quiz data read only
        private readonly QuizContext _context;

        /// <summary>
        /// Dependency injection, to get user info
        /// </summary>
        /// <param name="context">seeding data with its model</param>
        public UserInfoController(QuizContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Get/view all users, "GET" method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> Get()
        {
            return Ok(_context.Users.AsAsyncEnumerable());
        }
        
        // GET api/<UserInfoController>/5
        /// <summary>
        /// get single user
        /// </summary>
        /// <param name="id">use id to identify which user to get</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UserInfo> GetSingle(int id)
        {
            var user = _context.Users.Find(id);

            // if null, return not found, otherwise return user
            return user == null ? NotFound() : user;
        }

        /// <summary>
        /// "POST" method in api
        /// </summary>
        /// <param name="user">to create an user by following its model</param>
        [Authorize]
        [HttpPost]
        public void Post([FromBody] UserInfoCreate user)
        {
            // user model
            UserInfo newUser = new UserInfo
            {
                UserName = user.UserName,
                Password = user.Password
            };
            // add new user to list and save
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // PUT api/<UserInfoController>/5
        /// <summary>
        /// "PUT" method in API, to edit a user
        /// </summary>
        /// <param name="id">identify which user to be edit</param>
        /// <param name="user">user model</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<UserInfo> Put(int id, [FromBody] UserInfo user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid data");
            }
            // find user by id
            var existingUser = _context.Users.Where(c => c.UserInfoId == id).FirstOrDefault();
            if( existingUser != null)
            {
                // user model
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;

                // save change
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/<UserInfoController>/5
        /// <summary>
        /// "DELETE" user method in API
        /// </summary>
        /// <param name="id">identify which user will be deleted</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<UserInfo> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid Quiz id");
            }
            // location which user by its id
            var user = _context.Users.Where(c => c.UserInfoId == id).FirstOrDefault();

            // remove that user
            _context.Remove(user);

            // save changes
            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// a method to get all questions belong to one user 
        /// </summary>
        /// <param name="id">user id, identify which user</param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserInfoWithQuizs")]
        public ActionResult<UserInfo> GetWithQuizzes(int id)
        {
            // find user by its id first, then list all quizzes for this user
            UserInfo userInfo = _context.Users.Where(c => c.UserInfoId == id).Include(c => c.Quizzes).FirstOrDefault();

            if (userInfo != null)
            {
                return userInfo;
            }
            return NotFound();
        }
    }
}
