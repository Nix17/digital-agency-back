using Application.DTO.Common;
using Application.DTO.Dictionary;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class DictionaryProfile: Profile
{
    private readonly IMemoryCacheExtended _cache;

    public DictionaryProfile(IMemoryCacheExtended cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        CreateMap<DictionaryEntity, SiteTypeEntity>();
        CreateMap<DictionaryEntity, SiteModulesEntity>();
        CreateMap<DictionaryEntity, SiteDesignEntity>();
        CreateMap<DictionaryEntity, OptionalDesignEntity>();
        CreateMap<DictionaryEntity, SiteSupportEntity>();

        CreateMap<DictionaryEntity, KeyNameDescPriceDTO>();

        CreateMap<DictionaryForm, DictionaryEntity>();
        CreateMap<DictionaryForm, SiteTypeEntity>();
        CreateMap<DictionaryForm, SiteModulesEntity>();
        CreateMap<DictionaryForm, SiteDesignEntity>();
        CreateMap<DictionaryForm, OptionalDesignEntity>();
        CreateMap<DictionaryForm, SiteSupportEntity>();
    }
}
