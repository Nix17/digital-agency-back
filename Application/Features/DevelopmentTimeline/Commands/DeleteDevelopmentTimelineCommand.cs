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

namespace Application.Features.DevelopmentTimeline.Commands;

public class DeleteDevelopmentTimelineCommand: IRequest<Response<MessageResponse>>
{
    public DeleteDevelopmentTimelineCommand(List<int> ids)
    {
        Ids = ids;
    }

    public List<int> Ids { get; set; }
}

public class DeleteDevelopmentTimelineCommandHandler : IRequestHandler<DeleteDevelopmentTimelineCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public DeleteDevelopmentTimelineCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(DeleteDevelopmentTimelineCommand cmd, CancellationToken cancellationToken)
    {
        var items = await _uow.DevelopmentTimelineRepo.FindAllAsync(o => cmd.Ids.Contains(o.Id));
        await _uow.DevelopmentTimelineRepo.DeleteRangeAsync(items);
        var msg = $"Deleted: {items.Count} of {cmd.Ids}";
        var res = new MessageResponse(msg);
        return new Response<MessageResponse>(res);
    }
}

public class DeleteDevelopmentTimelineCommandValidator: AbstractValidator<DeleteDevelopmentTimelineCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteDevelopmentTimelineCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Ids)
            .MustAsync(IsExists)
            .WithMessage("{PropertyName}: Error! Do not exist entities!");
    }

    private async Task<bool> IsExists(List<int> ids, CancellationToken cancellationToken)
    {
        foreach(var id in ids)
        {
            if(!(await _uow.DevelopmentTimelineRepo.ExistsAsync(id))) return false;
        }
        return true;
    }
}