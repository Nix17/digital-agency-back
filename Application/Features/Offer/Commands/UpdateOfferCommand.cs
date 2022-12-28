﻿using Application.DTO.Offer;
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

namespace Application.Features.Offer.Commands;

public class UpdateOfferCommand: IRequest<Response<MessageResponse>>
{
    public UpdateOfferCommand(Guid id, OfferForm data)
    {
        Id = id;
        Data = data;
    }

    public Guid Id { get; set; }
    public OfferForm Data { get; set; }
}

public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateOfferCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(UpdateOfferCommand cmd, CancellationToken cancellationToken)
    {
        var obj = await _uow.OfferRepo.FindAsync(o => o.Id == cmd.Id);
        _mapper.Map(cmd.Data, obj);

        ICollection<OfferModulesEntity> offerModules = new List<OfferModulesEntity>();
        ICollection<OfferOptionalDesignsEntity> offerOptional = new List<OfferOptionalDesignsEntity>();
        ICollection<OfferSupportEntity> offerSupports = new List<OfferSupportEntity>();

        var collectionM = await _uow.OfferModuleRepo.FindAllAsync(o => o.OfferId == obj.Id);
        if (collectionM.Count > 0) await _uow.OfferModuleRepo.DeleteRangeAsync(collectionM);

        var collectionO = await _uow.OfferOptionalDesignsRepo.FindAllAsync(o => o.OfferId == obj.Id);
        if (collectionO.Count > 0) await _uow.OfferOptionalDesignsRepo.DeleteRangeAsync(collectionO);

        var collectionS = await _uow.OfferSupportRepo.FindAllAsync(o => o.OfferId == obj.Id);
        if (collectionS.Count > 0) await _uow.OfferSupportRepo.DeleteRangeAsync(collectionS);

        //#######################################################3

        foreach (var item in cmd.Data.SiteModulesIds)
        {
            offerModules.Add(new OfferModulesEntity(obj.Id, item));
        }

        foreach (var item in cmd.Data.OptionalDesignIds)
        {
            offerOptional.Add(new OfferOptionalDesignsEntity(obj.Id, item));
        }

        foreach (var item in cmd.Data.SiteSupportIds)
        {
            offerSupports.Add(new OfferSupportEntity(obj.Id, item));
        }

        await _uow.OfferModuleRepo.AddRangeAsync(offerModules);
        await _uow.OfferOptionalDesignsRepo.AddRangeAsync(offerOptional);
        await _uow.OfferSupportRepo.AddRangeAsync(offerSupports);

        await _uow.OfferRepo.UpdateAsync(obj);

        var msg = $"Offer with id = { obj.Id } was successful update!";
        return new Response<MessageResponse>(msg);
    }
}

public class UpdateOfferCommandValidator: AbstractValidator<UpdateOfferCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateOfferCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! Offer doesn't exist!");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OfferRepo.ExistsAsync(id);
    }
}