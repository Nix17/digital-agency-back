using Application.DTO.DevelopmentTimeline;
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

namespace Application.Features.DevelopmentTimeline.Commands;

public class CreateDevelopmentTimelineCommand: IRequest<Response<MessageResponse>>
{
    public CreateDevelopmentTimelineCommand(DevelopmentTimelineForm data)
    {
        Data = data;
    }

    public DevelopmentTimelineForm Data { get; set; }
}

public class CreateDevelopmentTimelineCommandHandler : IRequestHandler<CreateDevelopmentTimelineCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateDevelopmentTimelineCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(CreateDevelopmentTimelineCommand cmd, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<DevelopmentTimelineEntity>(cmd.Data);
        var res = await _uow.DevelopmentTimelineRepo.AddAsync(obj);
        var msg = $"Created new DevelopmentTimeline with id = { res.Id }";
        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}

public class CreateDevelopmentTimelineCommandValidator: AbstractValidator<CreateDevelopmentTimelineCommand>
{
}