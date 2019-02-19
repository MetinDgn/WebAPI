using FluentValidation;
using Mobilion.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilion.Business.ValidationRules.FluentValidation
{
    public class RegistryValidator : AbstractValidator<UserDto>
    {
        public RegistryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(6).Unless(x=> x.UserId != 0 && x.Password == string.Empty);
            RuleFor(x => x.PasswordConfirm).Equal(x=> x.Password);
        }
    }
}
