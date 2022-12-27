using Application.DTO.Common;
using Application.DTO.User;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class UserProfile: Profile
{
    private readonly IMemoryCacheExtended _cache;

    public UserProfile(IMemoryCacheExtended cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        CreateMap<UserAuthForm, UserEntity>();

        CreateMap<UserRegForm, UserEntity>()
            .ForMember(dest => dest.Role, opt => opt.Ignore());
        
        CreateMap<UserUpdateForm, UserEntity>();

        CreateMap<UserEntity, UserDTO>();
        CreateMap<UserEntity, KeyValueDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName[0] + "." + src.MiddleName[0] + "."))
            ;
    }
}
