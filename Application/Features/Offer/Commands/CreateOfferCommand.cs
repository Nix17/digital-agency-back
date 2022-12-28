using Application.DTO.Offer;
using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
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

        var msg = $"Created: new offer with id {resObj.Id}";

        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}
