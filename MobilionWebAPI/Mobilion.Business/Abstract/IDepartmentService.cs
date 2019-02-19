using Mobilion.Business.Dto;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Abstract
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        Department GetDepartmentById(int departmentId);
        Department Add(DepartmentDto department);  
        Department Update(DepartmentDto department);
        void Delete(int departmentId);
        List<User> GetUsersByDepartmentId(int departmentId);
        User GetUserByUserId(int userId);
    }
}
