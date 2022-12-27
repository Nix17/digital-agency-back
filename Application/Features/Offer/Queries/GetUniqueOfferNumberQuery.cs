using Application.Interfaces.Services;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offer.Queries;

public class GetUniqueOfferNumberQuery : IRequest<Response<int>>
{
    public GetUniqueOfferNumberQuery()
    {
    }
}

public class GetUniqueOfferNumberQueryHandler : IRequestHandler<GetUniqueOfferNumberQuery, Response<int>>
{
    private readonly IUnitOfWork _uow;

    public GetUniqueOfferNumberQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Response<int>> Handle(GetUniqueOfferNumberQuery req, CancellationToken cancellationToken)
    {
        var count = await _uow.OfferRepo.CountAsync();
        if (count > 0)
        {
            return new Response<int>(await _uow.OfferRepo.GetMaxOfferNumber());
        }
        return new Response<int>(1);
    }
}
