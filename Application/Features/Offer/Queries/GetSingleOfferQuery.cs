using Application.DTO.Common;
using Application.DTO.Offer;
using Application.DTO.Order;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offer.Queries;

public class GetSingleOfferQuery: IRequest<Response<OfferDTO>>
{
    public GetSingleOfferQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetSingleOfferQueryHandler : IRequestHandler<GetSingleOfferQuery, Response<OfferDTO>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetSingleOfferQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<OfferDTO>> Handle(GetSingleOfferQuery req, CancellationToken cancellationToken)
    {
        var offer = await _uow.OfferRepo.FindIncludingAsync(o => o.Id == req.Id, noTrack: true, x => x.User, x => x.DevelopmentTimeline, x => x.SiteType, x => x.SiteDesign, x => x.OfferModules, x => x.OfferOptionalDesigns, x => x.OfferSupports);

        var modulesIds = new List<int>();
        foreach (var item in offer.OfferModules)
        {
            modulesIds.Add(item.SiteModulesId);
        }
        var modules = await _uow.SiteModulesRepo.FindAllAsync(x => modulesIds.Contains(x.Id));
        var resMods = _mapper.Map<List<KeyNameDescPriceDTO>>(modules);

        //#########
        var optionalIds = new List<int>();
        foreach (var item in offer.OfferOptionalDesigns)
        {
            optionalIds.Add(item.OptionalDesignId);
        }
        var optionals = await _uow.OptionalDesignRepo.FindAllAsync(x => optionalIds.Contains(x.Id));
        var resOptionals = _mapper.Map<List<KeyNameDescPriceDTO>>(optionals);

        //############
        var supportIds = new List<int>();
        foreach (var item in offer.OfferSupports)
        {
            supportIds.Add(item.SiteSupportId);
        }
        var support = await _uow.SiteModulesRepo.FindAllAsync(x => supportIds.Contains(x.Id));
        var resSupport = _mapper.Map<List<KeyNameDescPriceDTO>>(support);

        var res = _mapper.Map<OfferDTO>(offer);
        res.SiteModules = resMods;
        res.OptionalDesign = resOptionals;
        res.SitySupport = resSupport;

        return new Response<OfferDTO>(res);
    }
}

public class GetSingleOfferQueryValidator: AbstractValidator<GetSingleOfferQuery>
{
    private readonly IUnitOfWork _uow;

    public GetSingleOfferQueryValidator(IUnitOfWork uow)
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