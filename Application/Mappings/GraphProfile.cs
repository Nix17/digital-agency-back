using Application.DTO.GraphData;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class GraphProfile: Profile
{
    private readonly IMemoryCacheExtended _cache;

    public GraphProfile(IMemoryCacheExtended cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        CreateMap<OfferEntity, GraphDate>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Created))
            ;

        CreateMap<OrderEntity, GraphDate>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Created));
    }
}
