using Application.DTO.Common;
using Application.DTO.Offer;
using Application.DTO.Order;
using Application.DTO.User;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offer.Queries;

public class GetAllOffersQuery : IRequest<Response<List<OfferDTO>>>
{
    public GetAllOffersQuery()
    {
    }
}

public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQuery, Response<List<OfferDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllOffersQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<OfferDTO>>> Handle(GetAllOffersQuery req, CancellationToken cancellationToken)
    {
        var resultsOffers = new List<OfferDTO>();
        var offers = await _uow.OfferRepo.GetAllIncludingAsync(noTrack: true, x => x.User, x => x.DevelopmentTimeline, x => x.SiteType, x => x.SiteDesign, x => x.OfferModules, x => x.OfferOptionalDesigns, x => x.OfferSupports);

        foreach(var offer in offers)
        {
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

            resultsOffers.Add(res);
        }

        return new Response<List<OfferDTO>>(resultsOffers);
    }
}
