using Mobilion.Business.Dto;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Helpers
{
    internal class UserMapper
    {
        public static User UserDtoToUser(UserDto user)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            return new User()
            {
                UserId = user.UserId,
                DepartmentId = user.DepartmentId,
                UserName = user.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Description = user.Description
            };
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
