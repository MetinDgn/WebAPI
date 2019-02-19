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
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        [HttpGet]
        [Route("get")]
        public ActionResult GetAllDepartment()
        {
            var departments = _departmentService.GetAll();
            return Ok(departments);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetDepartmentById(int departmentId)
        {
            var department = _departmentService.GetDepartmentById(departmentId);
            return Ok(department);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]DepartmentDto department)
        {
            var retDepartment = _departmentService.Add(department);
            return Ok(department);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateDepartment([FromBody]DepartmentDto department)
        {
            var retUser = _departmentService.Update(department);
            return Ok(retUser);
        }

        [HttpGet]
        [Route("users")]
        public ActionResult GetUsersByDepartmentId(int departmentId)
        {
            var users = _departmentService.GetUsersByDepartmentId(departmentId);
            return Ok(users);
        }

        [HttpGet]
        [Route("userdetail")]
        public ActionResult GetUserByUserId(int userId)
        {
            var user = _departmentService.GetUserByUserId(userId);
            return Ok(user);
        }
    }
}