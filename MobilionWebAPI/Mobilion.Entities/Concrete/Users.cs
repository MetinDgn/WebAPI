using Mobilion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Entities.Concrete
{
    public class User :IEntity
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
