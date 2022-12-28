using Application.DTO.User;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands;

public class RegistrationCommand: IRequest<Response<Account>>
{
    public RegistrationCommand(UserRegForm form)
    {
        Form = form;
    }

    public UserRegForm Form { get; set; }
}

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Response<Account>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public RegistrationCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<Account>> Handle(RegistrationCommand cmd, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<UserEntity>(cmd.Form);
        var addObj = await _uow.UserRepo.AddAsync(obj);
        var result = _mapper.Map<Account>(addObj);
        return new Response<Account>(result);
    }
}

public class RegistrationCommandValidator: AbstractValidator<RegistrationCommand>
{
    private readonly IUnitOfWork _uow;

    public RegistrationCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Form.Email)
            .MustAsync(IsUnregEmail).WithMessage("{PropertyName}: error! Email already taken!");
    }

    private async Task<bool> IsUnregEmail(string email, CancellationToken cancellationToken)
    {
        var obj = await _uow.UserRepo.FindAsync(o => o.Email == email);
        if (obj != null)
        {
            return false;
        }

        return true;
    }
}