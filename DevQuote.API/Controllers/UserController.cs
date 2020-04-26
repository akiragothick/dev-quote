using DevQuote.API.Base;
using DevQuote.API.Controllers.Base;
using DevQuote.API.DataTransferObject;
using DevQuote.API.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DevQuote.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerGeneric<Response<User>>
    {
        private readonly DevQuoteDBContext _context;
        private readonly IConfiguration configuration;

        public UserController(DevQuoteDBContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public ActionResult<Response<User>> Login(User user)
        {
            var userFind = _context.User.Where(x => x.email.Equals(user.email)).FirstOrDefault();

            if (userFind == null)
                return NotFound();
            else
                userFind.password = null;

            var claims = new[]
            {
                new Claim("UserTokenData",JsonConvert.SerializeObject(userFind))
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                notBefore: DateTime.Now,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            user.token = new JwtSecurityTokenHandler().WriteToken(token);

            Response<User> userReturn = new Response<User>()
            {
                Data = user
            };

            return userReturn;
        }

        [HttpGet("hi")]
        public ActionResult<string> Hello() => $"Hello world {DateTime.Now.Year}";
    }
}
