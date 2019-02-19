using Mobilion.Business.Dto;
using Mobilion.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserDto user);
        User Login(Dto.LoginDto user);
    }
}
