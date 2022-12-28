using Application.DTO.Offer;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offer.Commands;

public class CreateOfferCommand: IRequest<Response<MessageResponse>>
{
    public CreateOfferCommand(OfferForm data)
    {
        Data = data;
    }

    public OfferForm Data { get; set; }
}

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateOfferCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(CreateOfferCommand cmd, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<OfferEntity>(cmd.Data);
        var offerModules = new List<OfferModulesEntity>();
        var offerOptional = new List<OfferOptionalDesignsEntity>();
        var offerSupports = new List<OfferSupportEntity>();

        var resObj = await _uow.OfferRepo.AddAsync(obj);

        foreach (var item in cmd.Data.SiteModulesIds)
        {
            offerModules.Add(new OfferModulesEntity(resObj.Id, item));
        }

        foreach (var item in cmd.Data.OptionalDesignIds)
        {
            offerOptional.Add(new OfferOptionalDesignsEntity(resObj.Id, item));
        }

        foreach (var item in cmd.Data.SiteSupportIds)
        {
            offerSupports.Add(new OfferSupportEntity(resObj.Id, item));
        }

        await _uow.OfferModuleRepo.AddRangeAsync(offerModules);
        await _uow.OfferOptionalDesignsRepo.AddRangeAsync(offerOptional);
        await _uow.OfferSupportRepo.AddRangeAsync(offerSupports);

        var msg = $"{resObj.Id}";

        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}

public class CreateOfferCommandValidator: AbstractValidator<CreateOfferCommand>
{
    private readonly IUnitOfWork _uow;

    public CreateOfferCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Data.OfferNumber).MustAsync(IsNumUnique).WithMessage("{PropertyName}: error! OfferNumber not unique!");

        RuleFor(p => p.Data.UserId).MustAsync(IsUserExist).WithMessage("{PropertyName}: error! UserId doesn't exist!");

        RuleFor(p => p.Data.DevelopmentTimelineId).MustAsync(IsDevTimeExist).WithMessage("{PropertyName}: error! DevelopmentTimelineId doesn't exist!");

        RuleFor(p => p.Data.SiteDesignId).MustAsync(IsSiteDesignExist).WithMessage("{PropertyName}: error! SiteDesignId doesn't exist!");

        RuleFor(p => p.Data.SiteModulesIds).MustAsync(IsSiteModulesIdsExist).WithMessage("{PropertyName}: error! SiteModulesIds doesn't exist!");

        RuleFor(p => p.Data.OptionalDesignIds).MustAsync(IsOptionalDesignIdsExist).WithMessage("{PropertyName}: error! OptionalDesignIds doesn't exist!");

        RuleFor(p => p.Data.SiteSupportIds).MustAsync(IsSiteSupportIdsExist).WithMessage("{PropertyName}: error! SiteSupportIds doesn't exist!");

        RuleFor(p => p.Data.SiteTypeId).MustAsync(IsSiteTypeExist).WithMessage("{PropertyName}: error! SiteTypeId doesn't exist!");
    }

    private async Task<bool> IsNumUnique(int num, CancellationToken cancellationToken)
    {
        if ((await _uow.OfferRepo.FindAsync(o => o.OfferNumber == num)) != null) return false;
        return true;
    }

    private async Task<bool> IsUserExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }

    private async Task<bool> IsDevTimeExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.DevelopmentTimelineRepo.ExistsAsync(id);
    }

    private async Task<bool> IsSiteTypeExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.SiteTypeRepo.ExistsAsync(id);
    }

    private async Task<bool> IsSiteDesignExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.SiteDesignRepo.ExistsAsync(id);
    }

    private async Task<bool> IsSiteModulesIdsExist(List<int> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.SiteModulesRepo.ExistsAsync(id))) return false;
        }
        return true;
    }

    private async Task<bool> IsOptionalDesignIdsExist(List<int> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.OptionalDesignRepo.ExistsAsync(id))) return false;
        }
        return true;
    }

    private async Task<bool> IsSiteSupportIdsExist(List<int> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.SiteSupportRepo.ExistsAsync(id))) return false;
        }
        return true;
    }
}