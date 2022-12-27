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