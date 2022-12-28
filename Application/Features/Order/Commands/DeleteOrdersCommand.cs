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

namespace Application.Features.Order.Commands;

public class DeleteOrdersCommand: IRequest<Response<MessageResponse>>
{
    public DeleteOrdersCommand(List<Guid> ids)
    {
        Ids = ids;
    }

    public List<Guid> Ids { get; set; }
}

public class DeleteOrdersCommandHandler : IRequestHandler<DeleteOrdersCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public DeleteOrdersCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(DeleteOrdersCommand cmd, CancellationToken cancellationToken)
    {
        var items = await _uow.OrderRepo.FindAllAsync(o => cmd.Ids.Contains(o.Id));
        await _uow.OrderRepo.DeleteRangeAsync(items);
        var msg = $"Deleted: {items.Count} of {cmd.Ids}";
        var res = new MessageResponse(msg);
        return new Response<MessageResponse>(res);
    }
}

public class DeleteOrdersCommandValidator: AbstractValidator<DeleteOrdersCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrdersCommandValidator(IUnitOfWork uow)
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
            if (!(await _uow.OrderRepo.ExistsAsync(id))) return false;
        }
        return true;
    }
}