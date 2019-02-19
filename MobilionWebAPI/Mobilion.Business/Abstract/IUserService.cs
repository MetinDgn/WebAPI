using Mobilion.Business.Dto;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetUserById(int userId);
        User Update(UserDto user);
        void Delete(int userId);
        void UserExists(string userName);
        void DepartmentExists(int departmentId);
    }
}
