using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User;

public class UserAuthForm
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UserAuthFormValidator : AbstractValidator<UserAuthForm>
{
    public UserAuthFormValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");
    }
}