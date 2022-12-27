using Application.DTO.Offer;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class OfferProfile: Profile
{
    private readonly IMemoryCacheExtended _cache;

    public OfferProfile(IMemoryCacheExtended cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        CreateMap<OfferForm, OfferEntity>();
        CreateMap<OfferEntity, OfferDTO>();
    }
}
