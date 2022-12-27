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

public class DeleteUserCommand: IRequest<Response<MessageResponse>>
{
    public DeleteUserCommand(List<Guid> ids)
    {
        Ids = ids;
    }

    public List<Guid> Ids { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(DeleteUserCommand cmd, CancellationToken cancellationToken)
    {
        var items = await _uow.UserRepo.FindAllAsync(o => cmd.Ids.Contains(o.Id));
        await _uow.UserRepo.DeleteRangeAsync(items);
        var msg = $"Deleted: {items.Count} of {cmd.Ids}";
        var res = new MessageResponse(msg);
        return new Response<MessageResponse>(res);
    }
}

public class DeleteUserCommandValidator: AbstractValidator<DeleteUserCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteUserCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Ids)
            .MustAsync(IsExists)
            .WithMessage("{PropertyName}: Error! Do not exist entities!");
    }

    private async Task<bool> IsExists(List<Guid> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.UserRepo.ExistsAsync(id))) return false;
        }
        return true;
    }
}