using Application.DTO.DevelopmentTimeline;
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

public class UpdateDevelopmentTimelineCommand: IRequest<Response<MessageResponse>>
{
    public UpdateDevelopmentTimelineCommand(int id, DevelopmentTimelineForm form)
    {
        Id = id;
        this.Form = form;
    }

    public int Id { get; set; }
    public DevelopmentTimelineForm Form { get; set; }
}

public class UpdateDevelopmentTimelineCommandHandler : IRequestHandler<UpdateDevelopmentTimelineCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateDevelopmentTimelineCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(UpdateDevelopmentTimelineCommand cmd, CancellationToken cancellationToken)
    {
        var obj = await _uow.DevelopmentTimelineRepo.FindAsync(o => o.Id == cmd.Id);
        _mapper.Map(cmd.Form, obj);
        await _uow.DevelopmentTimelineRepo.UpdateAsync(obj);
        var msg = $"Entity with id = { obj.Id } was successful update!";
        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}

public class UpdateDevelopmentTimelineCommandValidator: AbstractValidator<UpdateDevelopmentTimelineCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateDevelopmentTimelineCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: error! not exist!");
    }

    private async Task<bool> IsExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.DevelopmentTimelineRepo.ExistsAsync(id);
    }
}