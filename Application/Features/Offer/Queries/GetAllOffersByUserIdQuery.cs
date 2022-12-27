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
        var items = await _uow.OfferRepo.FindAllAsync(o => o.UserId == req.Id);
        var res = _mapper.Map<List<OfferDTO>>(items);
        return new Response<List<OfferDTO>>(res);
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