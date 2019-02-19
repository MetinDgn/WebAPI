using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
