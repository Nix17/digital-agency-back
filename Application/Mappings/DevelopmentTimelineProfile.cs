using Application.DTO.DevelopmentTimeline;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class DevelopmentTimelineProfile: Profile
{
    private readonly IMemoryCacheExtended _cache;

    public DevelopmentTimelineProfile(IMemoryCacheExtended cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        CreateMap<DevelopmentTimelineForm, DevelopmentTimelineEntity>();

        CreateMap<DevelopmentTimelineEntity, DevelopmentTimelineDTO>();
    }
}
