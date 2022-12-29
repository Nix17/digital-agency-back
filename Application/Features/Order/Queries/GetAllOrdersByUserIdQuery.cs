using Application.DTO.Common;
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

namespace Application.Features.Order.Queries;

public class GetAllOrdersByUserIdQuery: IRequest<Response<List<OrderDTO>>>
{
    public GetAllOrdersByUserIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetAllOrdersByUserIdQueryHandler : IRequestHandler<GetAllOrdersByUserIdQuery, Response<List<OrderDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllOrdersByUserIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<OrderDTO>>> Handle(GetAllOrdersByUserIdQuery req, CancellationToken cancellationToken)
    {
        var resultsOrders = new List<OrderDTO>();

        var orders = await _uow.OrderRepo.FindAllIncludingAsync(o => o.UserId == req.Id, noTrack: true, x => x.User, x => x.Offer);
        foreach (var order in orders)
        {
            var offer = await _uow.OfferRepo.FindIncludingAsync(o => o.Id == order.OfferId, noTrack: true, x => x.User, x => x.DevelopmentTimeline, x => x.SiteType, x => x.SiteDesign, x => x.OfferModules, x => x.OfferOptionalDesigns, x => x.OfferSupports);

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

            order.Offer = offer;
            var res = _mapper.Map<OrderDTO>(order);
            res.Offer.SiteModules = resMods;
            res.Offer.OptionalDesign = resOptionals;
            res.Offer.SitySupport = resSupport;

            resultsOrders.Add(res);
        }
        return new Response<List<OrderDTO>>(resultsOrders);
    }
}

public class GetAllOrdersByUserIdQueryValidator: AbstractValidator<GetAllOrdersByUserIdQuery>
{
    private readonly IUnitOfWork _uow;

    public GetAllOrdersByUserIdQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! User isn't exist!");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }
}