using Application.DTO.Common;
using Application.DTO.Order;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Order.Queries;

public class GetSingleOrderQuery: IRequest<Response<OrderDTO>>
{
    public GetSingleOrderQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetSingleOrderQueryHandler : IRequestHandler<GetSingleOrderQuery, Response<OrderDTO>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetSingleOrderQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<OrderDTO>> Handle(GetSingleOrderQuery req, CancellationToken cancellationToken)
    {
        var order = await _uow.OrderRepo.FindIncludingAsync(o => o.Id == req.Id, noTrack: true, x => x.User, x => x.Offer);

        var offer = await _uow.OfferRepo.FindIncludingAsync(o => o.Id == order.OfferId, noTrack: true, x => x.User, x => x.DevelopmentTimeline, x => x.SiteType, x => x.SiteDesign, x => x.OfferModules, x => x.OfferOptionalDesigns, x => x.OfferSupports);

        var modulesIds = new List<int>();
        foreach(var item in offer.OfferModules)
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

        order.Offer = offer;
        var res = _mapper.Map<OrderDTO>(order);
        res.Offer.SiteModules = resMods;
        res.Offer.OptionalDesign = resOptionals;
        res.Offer.SitySupport = resSupport;
        return new Response<OrderDTO>(res);
    }
}

public class GetSingleOrderQueryValidator: AbstractValidator<GetSingleOrderQuery>
{
    private readonly IUnitOfWork _uow;

    public GetSingleOrderQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! Order doesn't exist");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OrderRepo.ExistsAsync(id);
    }
}