using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobilion.Business.Concrete;
using Mobilion.Business.Dto;
using Mobilion.Business.ValidationRules.FluentValidation;
using Mobilion.DataAccess.Abstract;
using Moq;
using System;

namespace Mobilion.Business.Test
{
    [TestClass]
    public class AuthManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void User_validation_check()
        {
            /*çalımadı.Araştırmak için yeterli zamanım olmadı*/
            Mock<IUserDal> mock = new Mock<IUserDal>();
            //Mock<IValidator<UserDto>> mock2 = new Mock<RegistryValidator>();
            AuthManager manager = new AuthManager(mock.Object);

            manager.Register(new Dto.UserDto() { UserName = new Guid().ToString(),DepartmentId = 100, Password ="12345", PasswordConfirm="43214" });
        }

    }
}
