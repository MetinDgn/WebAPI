using Mobilion.Business.Abstract;
using Mobilion.Business.Dto;
using Mobilion.DataAccess.Abstract;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            this._departmentDal = departmentDal;
        }
        public List<Department> GetAll()
        {
            return _departmentDal.GetList();
        }
        public Department GetDepartmentById(int departmentId)
        {
            return _departmentDal.Get(x => x.DepartmentId == departmentId);
        }
        public Department Add(DepartmentDto department)
        {
            if (department.DepartmentId != 0)
                throw new Exception("DepartmentId must be zero");
            var retDepartment = Helpers.DepartmentMapper.DepartmentDtoToDepartment(department);
            return _departmentDal.Add(retDepartment);
        }
        public Department Update(DepartmentDto department)
        {
            var retDepartment = GetDepartmentById(department.DepartmentId);
            if (retDepartment == null)
                throw new Exception("Can not find department for update");
            retDepartment = Helpers.DepartmentMapper.DepartmentDtoToDepartment(department);
            return _departmentDal.Update(retDepartment);
        }
        public void Delete(int departmentId)
        {
            _departmentDal.Add(new Department() { DepartmentId = departmentId });
        }
        public List<User> GetUsersByDepartmentId(int departmentId)
        {
            return _departmentDal.GetUsersByDepartmentId(departmentId);
        }
        public User GetUserByUserId(int userId)
        {
            return _departmentDal.GetUserByUserId(userId);
        }

    }
}
