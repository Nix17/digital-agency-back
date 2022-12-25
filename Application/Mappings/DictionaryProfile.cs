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

        CreateMap<DictionaryEntity, SiteTypeEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryEntity, SiteModulesEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryEntity, SiteDesignEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryEntity, OptionalDesignEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryEntity, SiteSupportEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;

        CreateMap<DictionaryEntity, KeyNameDescPriceDTO>();

        //CreateMap<SiteTypeEntity, KeyNameDescPriceDTO>();
        //CreateMap<SiteModulesEntity, KeyNameDescPriceDTO>();
        //CreateMap<SiteDesignEntity, KeyNameDescPriceDTO>();
        //CreateMap<OptionalDesignEntity, KeyNameDescPriceDTO>();
        //CreateMap<SiteSupportEntity, KeyNameDescPriceDTO>();


        CreateMap<DictionaryForm, DictionaryEntity>();
        CreateMap<DictionaryForm, SiteTypeEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryForm, SiteModulesEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryForm, SiteDesignEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryForm, OptionalDesignEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
        CreateMap<DictionaryForm, SiteSupportEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            ;
    }
}
