using FluentValidation;
using Kino.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Entity.Validators
{
    public class RegisterUserDtoValidator:AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator( CinemaDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Pass)
                .MinimumLength(6);
            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Pass);
            RuleFor(x => x.Email)
                .Custom((value, contex) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        contex.AddFailure("Email", "Email is taken");
                    }
                });
        }
    }
}
