using Application.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.User;

public class UserRegForm
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
}

public class UserRegFormValidator : AbstractValidator<UserRegForm>
{
    public UserRegFormValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName}: error! must not empty")
            .NotNull().WithMessage("{PropertyName}: error! must not null")
            ;

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");

        RuleFor(p => p.Phone)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");

        RuleFor(p => p.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");

        RuleFor(p => p.MiddleName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");
    }
}