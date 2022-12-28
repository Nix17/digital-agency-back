using Application.DTO.Order;
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

namespace Application.Features.Order.Queries;

public class GetAllOrdersByUserIdQuery: IRequest<Response<List<OrderDTO>>>
{
    public GetAllOrdersByUserIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetAllOrdersByUserIdQueryHandler : IRequestHandler<GetAllOrdersByUserIdQuery, Response<List<OrderDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllOrdersByUserIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<OrderDTO>>> Handle(GetAllOrdersByUserIdQuery req, CancellationToken cancellationToken)
    {
        var items = await _uow.OrderRepo.FindAllAsync(o => o.UserId == req.Id);
        var res = _mapper.Map<List<OrderDTO>>(items);
        return new Response<List<OrderDTO>>(res);
    }
}

public class GetAllOrdersByUserIdQueryValidator: AbstractValidator<GetAllOrdersByUserIdQuery>
{
    private readonly IUnitOfWork _uow;

    public GetAllOrdersByUserIdQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! User isn't exist!");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }
}