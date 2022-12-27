using Application.DTO.Offer;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
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

    public Task<Response<MessageResponse>> Handle(CreateOfferCommand cmd, CancellationToken cancellationToken)
    {
        //var obj = _mapper.Map<Off>
        throw new Exception();
    }
}
