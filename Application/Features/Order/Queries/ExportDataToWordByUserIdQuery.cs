﻿using Application.DTO.Common;
using Application.DTO.Order;
using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;
using FluentValidation;

namespace Application.Features.Order.Queries;

public class ExportDataToWordUserIdQuery : IRequest<byte[]>
{
    public ExportDataToWordUserIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}

public class ExportDataToWordUserIdQueryHandler : IRequestHandler<ExportDataToWordUserIdQuery, byte[]>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public ExportDataToWordUserIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<byte[]> Handle(ExportDataToWordUserIdQuery req, CancellationToken cancellationToken)
    {
        var resultsOrders = new List<OrderDTO>();

        var orders = await _uow.OrderRepo.FindAllIncludingAsync(o => o.UserId == req.UserId, noTrack: true, x => x.User, x => x.Offer);
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

        using(MemoryStream mem = new MemoryStream())
        {
            using (var document = DocX.Create(mem))
            {
                foreach(var item in resultsOrders)
                {
                    document.InsertParagraph($"Заказ id = { item.Id }");
                    document.InsertParagraph($"Заказчик: { item.User.Value }");
                    document.InsertParagraph($"Сумма: { item.OrderCost }");
                    document.InsertParagraph($"Дата заказа: { item.OrderDate }");
                    document.InsertParagraph("#####################################################################");
                    document.InsertParagraph("---------------------------------------------------------------------");
                    document.InsertParagraph("**********************************************************************");
                    document.InsertParagraph("");
                    document.InsertParagraph("");
                }

                document.Save();
            }

            return mem.ToArray();
        }
    }
}

public class ExportDataToWordUserIdQueryValidator: AbstractValidator<ExportDataToWordUserIdQuery>
{
    private readonly IUnitOfWork _uow;

    public ExportDataToWordUserIdQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.UserId)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error!: Такого пользователя не существует!");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }
}
