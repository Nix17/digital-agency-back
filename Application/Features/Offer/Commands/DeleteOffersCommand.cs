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

public class DeleteOffersCommand: IRequest<Response<MessageResponse>>
{
    public DeleteOffersCommand(List<Guid> ids)
    {
        Ids = ids;
    }

    public List<Guid> Ids { get; set; }
}

public class DeleteOffersCommandHandler : IRequestHandler<DeleteOffersCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public DeleteOffersCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(DeleteOffersCommand cmd, CancellationToken cancellationToken)
    {
        var items = await _uow.OfferRepo.FindAllAsync(o => cmd.Ids.Contains(o.Id));

        ICollection<OfferModulesEntity> offerModules = new List<OfferModulesEntity>();
        ICollection<OfferOptionalDesignsEntity> offerOptional = new List<OfferOptionalDesignsEntity>();
        ICollection<OfferSupportEntity> offerSupports = new List<OfferSupportEntity>();

        foreach (var item in items)
        {
            var collection = await _uow.OfferModuleRepo.FindAllAsync(o => o.OfferId == item.Id);
            offerModules = collection.ToList();
            if (offerModules.Count > 0) await _uow.OfferModuleRepo.DeleteRangeAsync(offerModules);
        }

        foreach (var item in items)
        {
            var collection = await _uow.OfferOptionalDesignsRepo.FindAllAsync(o => o.OfferId == item.Id);
            offerOptional = collection.ToList();
            if (offerOptional.Count > 0) await _uow.OfferOptionalDesignsRepo.DeleteRangeAsync(offerOptional);
        }

        foreach (var item in items)
        {
            var collection = await _uow.OfferSupportRepo.FindAllAsync(o => o.OfferId == item.Id);
            offerSupports = collection.ToList();
            if (offerSupports.Count > 0) await _uow.OfferSupportRepo.DeleteRangeAsync(offerSupports);
        }

        await _uow.OfferRepo.DeleteRangeAsync(items);
        var msg = $"Deleted: {items.Count} of {cmd.Ids}";
        var res = new MessageResponse(msg);
        return new Response<MessageResponse>(res);
    }
}

public class DeleteOffersCommandValidator: AbstractValidator<DeleteOffersCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteOffersCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Ids)
            .MustAsync(IsExists)
            .WithMessage("{PropertyName}: Error! Do not exist entities!");
    }

    private async Task<bool> IsExists(List<Guid> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.OfferRepo.ExistsAsync(id))) return false;
        }
        return true;
    }
}