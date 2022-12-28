using Application.DTO.User;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands;

public class LoginCommand: IRequest<Response<Account>>
{
    public LoginCommand(UserAuthForm form)
    {
        Form = form;
    }

    public UserAuthForm Form { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<Account>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public LoginCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<Account>> Handle(LoginCommand cmd, CancellationToken cancellationToken)
    {
        var obj = await _uow.UserRepo.FindAsync(o => o.Email == cmd.Form.Email && o.Password == cmd.Form.Password);
        if (obj == null) throw new ApiException("No found user");

        var result = _mapper.Map<Account>(obj);
        return new Response<Account>(result);
    }
}

public class LoginCommandValidator: AbstractValidator<LoginCommand>
{
    private readonly IUnitOfWork _uow;

    public LoginCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Form.Email)
            .MustAsync(IsUserExist)
            .WithMessage("{PropertyName}: Error! User not exist!");
    }

    private async Task<bool> IsUserExist(string email, CancellationToken cancellationToken)
    {
        var obj = await _uow.UserRepo.FindAsync(o => o.Email == email);
        if (obj != null) return true;
        else return false;
    }
}