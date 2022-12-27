using Application.DTO.User;
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

namespace Application.Features.User.Commands;

public class UpdateUserCommand: IRequest<Response<MessageResponse>>
{
    public UpdateUserCommand(Guid id, UserUpdateForm data)
    {
        Id = id;
        Data = data;
    }

    public Guid Id { get; set; }
    public UserUpdateForm Data { get; set; }
}

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(UpdateUserCommand cmd, CancellationToken cancellationToken)
    {
        var obj = await _uow.UserRepo.FindAsync(o => o.Id == cmd.Id);
        _mapper.Map(cmd.Data, obj);
        await _uow.UserRepo.UpdateAsync(obj);
        var msg = $"User with id = {obj.Id} was successful update!";
        return new Response<MessageResponse>(msg);
    }
}

public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateUserCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! User doesn't exist!");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }
}