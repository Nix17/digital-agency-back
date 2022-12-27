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
        var obj = await _uow.OfferRepo.FindAsync(o => o.Id == req.Id);
        var res = _mapper.Map<OfferDTO>(obj);
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