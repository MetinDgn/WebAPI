using Mobilion.Business.Abstract;
using Mobilion.Business.Dto;
using Mobilion.Business.ValidationRules.FluentValidation;
using Mobilion.Core.Aspects.Postsharp.ValidationAspects;
using Mobilion.DataAccess.Abstract;
using Mobilion.DataAccess.Concrete.EntityFramework;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }
        public List<User> GetAll()
        {
            return _userDal.GetList();
        }
        public User GetUserById(int userId)
        {
            return _userDal.Get(x => x.UserId == userId);
        }
        [FluentValidationAspect(typeof(RegistryValidator))]
        public User Update(UserDto user)
        {
            EfUserDal aa = new EfUserDal();
            var oldUser = GetUserById(user.UserId);
            if (oldUser == null)
                throw new Exception("Can not find user for update");
            if (oldUser.UserName != user.UserName)
                UserExists(user.UserName);
            if (oldUser.DepartmentId != user.DepartmentId)
                DepartmentExists(user.DepartmentId);
            var retUser = Helpers.UserMapper.UserDtoToUser(user);
            if(user.Password == string.Empty)
            {
                retUser.PasswordHash = oldUser.PasswordHash;
                retUser.PasswordSalt= oldUser.PasswordSalt;
            }
            return _userDal.Update(retUser);
        }
        public void Delete(int userId)
        {
            _userDal.Delete(new User() { UserId = userId });
        }
        public void UserExists(string userName)
        {
            var user = this._userDal.Get(x => x.UserName == userName);
            if (user != null)
                throw new Exception("UserName already exists.");
        }
        public void DepartmentExists(int departmentId)
        {
            var department = this._userDal.GetDepartmentByDepartmentId(departmentId);
            if (department == null)
                throw new Exception("Department not exists.");
        }
    }
}
