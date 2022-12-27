using Application.DTO.Offer;
using Application.DTO.User;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offer.Queries;

public class GetAllOffersQuery : IRequest<Response<List<OfferDTO>>>
{
    public GetAllOffersQuery()
    {
    }
}

public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQuery, Response<List<OfferDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllOffersQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<OfferDTO>>> Handle(GetAllOffersQuery req, CancellationToken cancellationToken)
    {
        var items = await _uow.OfferRepo.GetAllAsync();
        var res = _mapper.Map<List<OfferDTO>>(items).ToList();
        return new Response<List<OfferDTO>>(res);
    }
}
