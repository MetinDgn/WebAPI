using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilion.Business.Abstract;
using Mobilion.Business.Dto;

namespace MobilionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet]
        [Route("get")]
        public ActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateUser([FromBody]UserDto user)
        {
            var retUser = _userService.Update(user);
            return Ok(retUser);
        }
    }
}