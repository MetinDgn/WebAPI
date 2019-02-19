using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mobilion.Business.Abstract;
using Mobilion.Business.Dto;
using MobilionWebAPI.Model;

namespace MobilionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;
        private IConfiguration _configuration;
        public AuthController(IUserService userService, IAuthService authService, IConfiguration configuration)
        {
            this._userService = userService;
            this._authService = authService;
            this._configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto user)
        {
            _userService.UserExists(user.UserName);

            _userService.DepartmentExists(user.DepartmentId);

            _authService.Register(user);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto user)
        {
            var retUser = _authService.Login(user);
            if (retUser == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier,retUser.UserId.ToString()),
                    new Claim(ClaimTypes.Name,retUser.UserName)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
    }
}