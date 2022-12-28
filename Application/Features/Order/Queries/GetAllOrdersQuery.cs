using Application.DTO.Order;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries;

public class GetAllOrdersQuery : IRequest<Response<List<OrderDTO>>>
{
    public GetAllOrdersQuery()
    {
    }
}

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Response<List<OrderDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<OrderDTO>>> Handle(GetAllOrdersQuery req, CancellationToken cancellationToken)
    {
        var items = await _uow.OrderRepo.GetAllAsync();
        var res = _mapper.Map<List<OrderDTO>>(items);
        return new Response<List<OrderDTO>>(res);
    }
}
