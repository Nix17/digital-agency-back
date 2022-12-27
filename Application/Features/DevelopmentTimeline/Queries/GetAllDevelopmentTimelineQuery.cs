using Application.DTO.DevelopmentTimeline;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DevelopmentTimeline.Queries;

public class GetAllDevelopmentTimelineQuery : IRequest<Response<List<DevelopmentTimelineDTO>>>
{
    public GetAllDevelopmentTimelineQuery()
    {
    }
}

public class GetAllDevelopmentTimelineQueryHandler : IRequestHandler<GetAllDevelopmentTimelineQuery, Response<List<DevelopmentTimelineDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllDevelopmentTimelineQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<DevelopmentTimelineDTO>>> Handle(GetAllDevelopmentTimelineQuery request, CancellationToken cancellationToken)
    {
        var items = await _uow.DevelopmentTimelineRepo.GetAllAsync();
        var res = _mapper.Map<List<DevelopmentTimelineDTO>>(items).ToList();
        return new Response<List<DevelopmentTimelineDTO>>(res);
    }
}
