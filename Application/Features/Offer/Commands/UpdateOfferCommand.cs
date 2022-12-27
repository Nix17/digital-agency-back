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

namespace Application.Features.Offer.Commands;

public class UpdateOfferCommand: IRequest<Response<MessageResponse>>
{
    public UpdateOfferCommand(Guid id, OfferForm data)
    {
        Id = id;
        Data = data;
    }

    public Guid Id { get; set; }
    public OfferForm Data { get; set; }
}

public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateOfferCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public Task<Response<MessageResponse>> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class UpdateOfferCommandValidator: AbstractValidator<UpdateOfferCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateOfferCommandValidator(IUnitOfWork uow)
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