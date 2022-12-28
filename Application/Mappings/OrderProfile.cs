using Application.DTO.Order;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings;

public class OrderProfile: Profile
{
    private readonly IMemoryCacheExtended _cache;

    public OrderProfile(IMemoryCacheExtended cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        CreateMap<OrderForm, OrderEntity>();
        CreateMap<OrderEntity, OrderDTO>();
    }
}
