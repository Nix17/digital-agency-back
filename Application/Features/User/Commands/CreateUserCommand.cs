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

namespace Application.Features.User.Commands;

public class CreateUserCommand: IRequest<Response<MessageResponse>>
{
    public CreateUserCommand(UserRegForm form)
    {
        Data = form;
    }

    public UserRegForm Data { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(CreateUserCommand cmd, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<UserEntity>(cmd.Data);
        var res = await _uow.UserRepo.AddAsync(obj);
        var msg = $"Created: userId = { res.Id }";
        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    private readonly IUnitOfWork _uow;

    public CreateUserCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Data.Email)
            .MustAsync(IsUniqueEmail)
            .WithMessage("{PropertyName}: Error! This email is exist yet!");
    }

    private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
    {
        if(await _uow.UserRepo.FindAsync(o => o.Email == email) != null) return false;
        else return true;
    }
}