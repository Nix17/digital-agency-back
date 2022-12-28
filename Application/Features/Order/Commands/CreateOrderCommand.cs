using Application.DTO.Order;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands;

public class CreateOrderCommand: IRequest<Response<MessageResponse>>
{
    public CreateOrderCommand(OrderForm data)
    {
        Data = data;
    }

    public OrderForm Data { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(CreateOrderCommand cmd, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<OrderEntity>(cmd.Data);
        var res = await _uow.OrderRepo.AddAsync(obj);
        var msg = $"Created: new order with id { res.Id }";
        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}