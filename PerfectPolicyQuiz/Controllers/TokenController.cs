using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PerfectPolicyQuiz.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PerfectPolicyQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly QuizContext _context;

        #region Cofig
        public TokenController(IConfiguration config, QuizContext context)
        {
            _config = config;
            _context = context;
        }
        #endregion

        #region Public EndPoints
        // Generate a Token for an existing user
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {
            // All of the null checks
            if (_userData != null && _userData.UserName != null && _userData.Password != null)
            {
                // retrieve the user for these credentials
                var user = GetUser(_userData.UserName, _userData.Password);

                // If we have a user that matches the credentials
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {

                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _config["JWT:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserInfoId.ToString()),

                    //new Claim(ClaimsIdentity.DefaultRoleClaimType,"Admin"),
                    // JWT UserName
                    new Claim("UserName", user.UserName)
                   };

                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _config["JWT:Issuer"],
                        _config["JWT:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.UtcNow.AddDays(2),
                        signingCredentials: signIn);

                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion

        #region Private Methods
        private UserInfo GetUser(string userName, string passWord)
        {
            var user = _context.Users.Where(c => c.UserName.Equals(userName)).FirstOrDefault();

            if (user != null && user.UserName.Equals(userName) && user.Password.Equals(passWord))
            {
                return user;
            }
            return null;
        }
        #endregion
       
    }
}
