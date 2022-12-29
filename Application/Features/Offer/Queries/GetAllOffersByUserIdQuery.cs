using Application.DTO.Common;
using Application.DTO.Offer;
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

public class GetAllOffersByUserIdQuery: IRequest<Response<List<OfferDTO>>>
{
    public GetAllOffersByUserIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetAllOffersByUserIdQueryHandler : IRequestHandler<GetAllOffersByUserIdQuery, Response<List<OfferDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllOffersByUserIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<OfferDTO>>> Handle(GetAllOffersByUserIdQuery req, CancellationToken cancellationToken)
    {
        var resultsOffers = new List<OfferDTO>();
        var offers = await _uow.OfferRepo.FindAllIncludingAsync(o => o.UserId == req.Id, noTrack: true, x => x.User, x => x.DevelopmentTimeline, x => x.SiteType, x => x.SiteDesign, x => x.OfferModules, x => x.OfferOptionalDesigns, x => x.OfferSupports);

        foreach (var offer in offers)
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

public class GetAllOffersByUserIdQueryValidator: AbstractValidator<GetAllOffersByUserIdQuery>
{
    private readonly IUnitOfWork _uow;

    public GetAllOffersByUserIdQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsUserExist)
            .WithMessage("{PropertyName}: Error! User doesn't exist!");
    }

    private async Task<bool> IsUserExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }
}