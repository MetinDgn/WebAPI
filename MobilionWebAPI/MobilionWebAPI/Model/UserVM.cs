using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilionWebAPI.Model
{
    public class UserVM
    {
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
