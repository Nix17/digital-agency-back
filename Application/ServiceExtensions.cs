﻿using Application.Behaviours;
using Application.Interfaces.Services;
using Application.Mappings;
//using Application.Services;

using AutoMapper;

using FluentValidation;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            var cache = provider.GetService<IMemoryCacheExtended>();
            cfg.AddProfile(new GeneralProfile(cache));
            cfg.AddProfile(new DictionaryProfile(cache));
            cfg.AddProfile(new DevelopmentTimelineProfile(cache));
            cfg.AddProfile(new UserProfile(cache));
            cfg.AddProfile(new OfferProfile(cache));
            cfg.AddProfile(new OrderProfile(cache));
            cfg.AddProfile(new GraphProfile(cache));
        }).CreateMapper());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //services.AddTransient<IParsingService, ParsingService>();
    }
}