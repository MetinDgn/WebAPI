using Mobilion.Business.Abstract;
using Mobilion.Business.Dto;
using Mobilion.Business.ValidationRules.FluentValidation;
using Mobilion.Core.Aspects.Postsharp.ValidationAspects;
using Mobilion.DataAccess.Abstract;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserDal _userDal;

        public AuthManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }

        [FluentValidationAspect(typeof(RegistryValidator))]
        public User Register(UserDto user)
        {
            if (user.UserId != 0)
                throw new Exception("UserId must be zero");
            User savedUser = Helpers.UserMapper.UserDtoToUser(user);
            return _userDal.Add(savedUser);
        }
        public User Login(LoginDto user)
        {
            var retUser = _userDal.Get(x => x.UserName == user.UserName);
            if(!VerifyPasswordHash(user.Password, retUser.PasswordHash, retUser.PasswordSalt))
                return null;
            return retUser;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (passwordHash[i] != computedHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
